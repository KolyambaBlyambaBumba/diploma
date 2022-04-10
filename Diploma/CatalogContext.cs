using Diploma.Models;
using Microsoft.EntityFrameworkCore;

namespace Diploma;

public class CatalogContext : DbContext
{
	public CatalogContext(DbContextOptions<CatalogContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>(e =>
		{
			e.HasKey(x => x.Id);

			e.Property(x => x.Name);
			e.Property(x => x.Description);

			e.HasMany(x => x.Images).WithOne().HasForeignKey(x => x.ProductId);
		});

		modelBuilder.Entity<ProductImage>(e =>
		{
			e.HasKey(x => x.Id);

			e.Property(x => x.ImageMimeType);
			e.Property(x => x.ImageData);
		});
	}
}