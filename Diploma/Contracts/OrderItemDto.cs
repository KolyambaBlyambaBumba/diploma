using System.ComponentModel.DataAnnotations;

namespace Diploma.Contracts;

public class OrderItemDto
{
	[Required]
	public Guid ProductId { get; init; }

	[Required]
	[Range(1, 99)]
	public int Count { get; init; }
}