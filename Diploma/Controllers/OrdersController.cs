using System.Text;
using Diploma.Contracts;
using Diploma.Extensions;
using Diploma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Diploma.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
	private readonly DbSet<Product> productSet;

	public OrdersController(DbSet<Product> productSet)
	{
		this.productSet = productSet ?? throw new ArgumentNullException(nameof(productSet));
	}

	[HttpPost]
	public async Task CreateOrder(AddOrderDto addOrderDto, CancellationToken cancellationToken)
	{
		using var message = new MimeMessage
		{
			Subject = "Новый заказ",
			Body = new TextPart(TextFormat.Html)
			{
				Text = await GenerateEmailBody(addOrderDto, cancellationToken),
			},
			From =
			{
				new MailboxAddress("alwa_soap", "alwasoapsite@yandex.by"),
			},
			To =
			{
				new MailboxAddress(string.Empty, "alwasoap@yandex.ru"),
			},
		};

		using var sender = new SmtpClient();
		await sender.ConnectAsync("smtp.yandex.ru", cancellationToken: cancellationToken);
		await sender.AuthenticateAsync("alwasoapsite@yandex.by", "pxwwmxbzpvtuyrld", cancellationToken);
		await sender.SendAsync(message, cancellationToken);
		await sender.DisconnectAsync(true, cancellationToken);
	}

	private async Task<string> GenerateEmailBody(AddOrderDto addOrderDto, CancellationToken cancellationToken)
	{
		var sb = new StringBuilder();
		sb.Append("<html><title>Новый заказ</title><body>");
		sb.Append($"<div>Имя: {addOrderDto.Name}</div>");
		sb.Append($"<div>Email: {addOrderDto.Email}</div>");
		sb.Append($"<div>Телефон: {addOrderDto.Phone}</div>");
		sb.Append($"<div>Заказ:</div>");
		sb.Append("<table cellpadding=\"10px\" border=\"1px\" cellspacing=\"0\"><tr><th>Продукт</th><th>Цена</th><th>Количество</th><th>Сумма</th></tr>");

		var finalSum = 0M;
		foreach (var orderItemDto in addOrderDto.Items)
		{
			var product = await productSet.GetById(orderItemDto.ProductId, false, cancellationToken);
			var sum = product.Cost * orderItemDto.Count;
			finalSum += sum;
			sb.Append($"<tr><td>{product.Name}</td><td>{FormatPrice(product.Cost)}</td><td>{orderItemDto.Count}</td><td>{FormatPrice(sum)}</td></tr>");
		}

		sb.Append("</table>");
		sb.Append($"<div>Общая сумма: {FormatPrice(finalSum)}</div>");
		sb.Append("</body></html>");

		return sb.ToString();
	}

	private static string FormatPrice(decimal price) => $"{price:F2} руб";
}