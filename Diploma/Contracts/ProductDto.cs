namespace Diploma.Contracts;

public class ProductDto
{
	public string Id { get; init; } = null!;

	public string Name { get; init; } = null!;

	public string? Description { get; init; }

	public Uri? Image { get; init; }

	public decimal Cost { get; init; }
}