using System.ComponentModel.DataAnnotations;

namespace Diploma.Contracts;

public class AddOrderDto
{
	[Required]
	[MaxLength(100)]
	public string Name { get; init; } = null!;

	[Required]
	[EmailAddress]
	public string Email { get; init; } = null!;

	[Phone]
	public string? Phone { get; init; }

	[Required]
	public IReadOnlyCollection<OrderItemDto> Items { get; init; } = null!;
}