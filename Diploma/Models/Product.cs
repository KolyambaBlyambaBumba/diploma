namespace Diploma.Models;

public class Product
{
	public Guid Id { get; init; }

	public string Name { get; init; } = null!;

	public string? Description { get; init; }

#pragma warning disable CA1002
	public ICollection<ProductImage> Images { get; init; } = new List<ProductImage>();
#pragma warning restore CA1002
}