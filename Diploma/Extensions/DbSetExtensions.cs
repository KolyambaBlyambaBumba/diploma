using Diploma.Exceptions;
using Diploma.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Extensions;

public static class DbSetExtensions
{
	public static async Task<Product> GetById(this DbSet<Product> productSet, Guid productId, bool loadImages,
		CancellationToken cancellationToken)
	{
		var query = productSet.Where(x => x.Id == productId);
		if (loadImages)
		{
			query = query.Include(x => x.Images);
		}

		var product = await query.FirstOrDefaultAsync(cancellationToken);
		if (product == null)
		{
			throw new ItemNotFoundException($"Product with id {productId} was not found");
		}

		return product;
	}
}