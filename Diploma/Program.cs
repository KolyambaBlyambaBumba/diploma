using Diploma;
using Diploma.Extensions;
using Diploma.Models;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	Args = args,
	WebRootPath = Path.Combine("ClientApp", "build"),
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<CatalogContext>(builder.Configuration["connectionString"]);

builder.Services.AddAsyncInitializer(async sp =>
{
	var dbContext = sp.GetRequiredService<CatalogContext>();
	await dbContext.Database.EnsureCreatedAsync();
});

builder.Services.AddScoped(sp => sp.GetRequiredService<CatalogContext>().Set<Product>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

await app.InitAsync();
await app.RunAsync();