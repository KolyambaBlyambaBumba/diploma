namespace Diploma.Models;

public class ProductImage
{
	public Guid Id { get; init; }

	public Guid ProductId { get; init; }

#pragma warning disable CA1819
	public byte[] ImageData { get; init; } = null!;
#pragma warning restore CA1819

	public string ImageMimeType { get; init; } = null!;
}