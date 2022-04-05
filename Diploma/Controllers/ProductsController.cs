using System.Text.RegularExpressions;
using Diploma.Contracts;
using Diploma.Exceptions;
using Diploma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private static readonly Regex DataUrlRegex = new("^data:(.+?);base64,(.+)$", RegexOptions.Compiled);

	private readonly ILogger<ProductsController> logger;
	private readonly CatalogContext catalogContext;
	private readonly DbSet<Product> productSet;

	public ProductsController(ILogger<ProductsController> logger, CatalogContext catalogContext)
	{
		this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		this.catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
		productSet = catalogContext.Set<Product>();
	}

	[HttpGet]
	public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken)
	{
		return (await productSet
				.Select(x => new Product
				{
					Id = x.Id,
					Description = x.Description,
					Image = null,
					Name = x.Name,
					ImageMimeType = x.ImageMimeType,
				})
				.ToListAsync(cancellationToken))
			.Select(ToDto);
	}

	[HttpPost]
	public async Task<ProductDto> AddProduct(
		[FromBody] AddProductDto addProductDto, CancellationToken cancellationToken)
	{
		var parsedImage = ParseDataUrl(addProductDto.ImageDataUrl);
		var newProduct = new Product
		{
			Id = Guid.NewGuid(),
			Name = addProductDto.Name,
			Description = addProductDto.Description,
			Image = parsedImage?.Image,
			ImageMimeType = parsedImage?.MimeType,
		};
		productSet.Add(newProduct);

		await catalogContext.SaveChangesAsync(cancellationToken);

		return ToDto(newProduct);
	}

	[HttpDelete("{productId}")]
	public async Task DeleteProduct(Guid productId, CancellationToken cancellationToken)
	{
		var product = await GetProduct(productId, cancellationToken);
		productSet.Remove(product);
		await catalogContext.SaveChangesAsync(cancellationToken);
	}

	[HttpGet("{productId}/image")]
	public async Task<IActionResult> GetProductImage(Guid productId, CancellationToken cancellationToken)
	{
		var product = await GetProduct(productId, cancellationToken);

		if (product.Image == null)
		{
			throw new InvalidOperationException($"Products with id {productId} doesn't have an image");
		}

		return File(product.Image, product.ImageMimeType!);
	}

	private async Task<Product> GetProduct(Guid productId, CancellationToken cancellationToken)
	{
		var product = await productSet.FindAsync(new object[] { productId }, cancellationToken);
		if (product == null)
		{
			throw new ItemNotFoundException($"Product with id {productId} was not found");
		}

		return product;
	}

	private ProductDto ToDto(Product product) => new()
	{
		Id = product.Id.ToString(),
		Name = product.Name,
		Description = product.Description,
		ImageLink = !string.IsNullOrEmpty(product.ImageMimeType)
			? new Uri(Url.ActionLink(nameof(GetProductImage), values: new { productId = product.Id })!)
			: null,
	};

	private static (byte[] Image, string MimeType)? ParseDataUrl(string? dataUrl)
	{
		if (string.IsNullOrEmpty(dataUrl))
		{
			return null;
		}

		var result = DataUrlRegex.Match(dataUrl);
		if (!result.Success)
		{
			throw new InvalidOperationException("Invalid data URL for the product image");
		}

		return (Convert.FromBase64String(result.Groups[2].Value), result.Groups[1].Value);
	}
}