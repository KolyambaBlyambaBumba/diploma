using System.ComponentModel.DataAnnotations;

namespace Diploma.Contracts;

public class AddProductDto
{
	[Required]
	public string Name { get; init; } = null!;

	public string? Description { get; init; }

	public decimal Cost { get; init; }
}