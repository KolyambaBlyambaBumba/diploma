namespace Diploma.Models;

public class Product
{
	public Guid Id { get; init; }

	public string Name { get; init; } = null!;

	public string? Description { get; init; }

#pragma warning disable CA1819
	public byte[]? Image { get; init; }
#pragma warning restore CA1819

	public string? ImageMimeType { get; init; }
}