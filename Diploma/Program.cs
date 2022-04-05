using Diploma;
using Diploma.Extensions;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

await app.InitAsync();
await app.RunAsync();