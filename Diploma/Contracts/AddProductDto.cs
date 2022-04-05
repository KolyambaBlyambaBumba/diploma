using System.ComponentModel.DataAnnotations;

namespace Diploma.Contracts;

public class AddProductDto
{
	[Required]
	public string Name { get; init; } = null!;

	public string? Description { get; init; }

#pragma warning disable CA1056
	public string? ImageDataUrl { get; init; }
#pragma warning restore CA1056
}