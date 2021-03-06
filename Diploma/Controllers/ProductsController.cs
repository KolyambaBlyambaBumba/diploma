using Diploma.Contracts;
using Diploma.Extensions;
using Diploma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly ILogger<ProductsController> logger;
	private readonly CatalogContext catalogContext;
	private readonly DbSet<Product> productSet;
	private readonly IQueryable<Product> productQuery;
	private readonly DbSet<ProductImage> productImageSet;

	public ProductsController(ILogger<ProductsController> logger, CatalogContext catalogContext)
	{
		this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		this.catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
		productSet = catalogContext.Set<Product>();
		productImageSet = catalogContext.Set<ProductImage>();
		productQuery = productSet.OrderBy(x => x.Name);
	}

	[HttpGet]
	public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken cancellationToken) =>
		(await productQuery
			.Select(x => new Product
			{
				Id = x.Id,
				Description = x.Description,
				Name = x.Name,
				Images = x.Images.Select(y => new ProductImage { Id = y.Id }).ToList(),
				Cost = x.Cost,
			})
			.ToListAsync(cancellationToken)).Select(ToDto);

	[HttpGet("{id}")]
	public async Task<ProductDto> GetProductById(Guid id, CancellationToken cancellationToken) =>
		ToDto(await productSet.GetById(id, true, cancellationToken));

	[HttpPost]
	public async Task<ProductDto> AddProduct(
		[FromBody] AddProductDto addProductDto, CancellationToken cancellationToken)
	{
		var newProduct = new Product
		{
			Id = Guid.NewGuid(),
			Name = addProductDto.Name,
			Description = addProductDto.Description,
			Cost = addProductDto.Cost,
		};
		productSet.Add(newProduct);

		await catalogContext.SaveChangesAsync(cancellationToken);

		return ToDto(newProduct);
	}

	[HttpDelete("{productId}")]
	public async Task DeleteProduct(Guid productId, CancellationToken cancellationToken)
	{
		var product = await productSet.GetById(productId, false, cancellationToken);
		productSet.Remove(product);
		await catalogContext.SaveChangesAsync(cancellationToken);
	}

	[HttpGet("{productId}/image")]
	public async Task<IActionResult> GetProductImage(Guid productId, CancellationToken cancellationToken)
	{
		var product = await productSet.GetById(productId, true, cancellationToken);

		if (!product.Images.Any())
		{
			throw new InvalidOperationException($"Products with id {productId} doesn't have an image");
		}

		var image = product.Images.First();

		return File(image.ImageData, image.ImageMimeType);
	}

	[HttpPut("{productId}/image")]
	public async Task<IActionResult> UpdateProductImage(Guid productId, IFormFile productImage,
		CancellationToken cancellationToken)
	{
		await productSet.GetById(productId, false, cancellationToken);

		productImageSet.RemoveRange(await productImageSet.Where(x => x.ProductId == productId)
			.ToListAsync(cancellationToken));
		productImageSet.Add(new ProductImage
		{
			Id = Guid.NewGuid(),
			ProductId = productId,
			ImageData = await ReadFormFile(productImage, cancellationToken),
			ImageMimeType = productImage.ContentType,
		});

		await catalogContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}

	[HttpDelete("{productId}/image")]
	public async Task<IActionResult> DeleteProductImage(Guid productId, CancellationToken cancellationToken)
	{
		await productSet.GetById(productId, false, cancellationToken);

		productImageSet.RemoveRange(await productImageSet.Where(x => x.ProductId == productId)
			.ToListAsync(cancellationToken));

		await catalogContext.SaveChangesAsync(cancellationToken);

		return Ok();
	}

	private ProductDto ToDto(Product product) => new()
	{
		Id = product.Id.ToString(),
		Name = product.Name,
		Description = product.Description,
		Cost = product.Cost,
		Image = product.Images.Any()
			? new Uri(Url.ActionLink(nameof(GetProductImage), values: new { productId = product.Id })!)
			: null,
	};

	private static async Task<byte[]> ReadFormFile(IFormFile formFile, CancellationToken cancellationToken)
	{
		using var memoryStream = new MemoryStream((int)formFile.Length);
		await formFile.CopyToAsync(memoryStream, cancellationToken);
		return memoryStream.ToArray();
	}
}