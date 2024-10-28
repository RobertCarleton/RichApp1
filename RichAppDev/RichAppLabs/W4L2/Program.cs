using Microsoft.EntityFrameworkCore;
using W4L1P2.Data;
using W4L1P2.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AdDB>(opt => opt.UseInMemoryDatabase("Advertisement"));
var connectionString = builder.Configuration.GetConnectionString("Ad") ?? "Data Source=Ad.db";
builder.Services.AddSqlite<AdDB>(connectionString);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

var ads = app.MapGroup("/ads");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// GET all items
ads.MapGet("/", async (AdDB db) =>
    await db.Ads.ToListAsync());

// GET completed items
/*todoItems.MapGet("/complete", async (AdDB db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());*/

// GET item by Id
ads.MapGet("/{AdId}", async (int id, AdDB db) =>
    await db.Ads.FindAsync(id) is Ad todo
        ? Results.Ok(todo)
        : Results.NotFound());

// GET New endpoint to search by SellerName
ads.MapGet("/seller/{SellerName}", async (string seller, AdDB db) =>
    await db.Ads.Where(t => t.SellerName == seller).ToListAsync());
// GET New endpoint to search by Category
ads.MapGet("/category/{CategoryName}", async (string category, AdDB db) =>
{
    var filteredCat = await db.Ads
    .Where(t => t.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase))
    .OrderBy(t => t.AdName)
    .ToListAsync();

    return filteredCat.Any() ? Results.Ok(filteredCat) : Results.NotFound();

});

// POST new item
ads.MapPost("/", async (Ad ad, AdDB db) =>
{
    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{ad.AdId}", ad);
});

// PUT update item by ID
ads.MapPut("/{id}", async (int id, Ad inputAd, AdDB db) =>
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return Results.NotFound();

    //ad.AdId = inputAd.AdId;
    ad.AdName = inputAd.AdName;
    ad.SellerName = inputAd.SellerName;
    ad.Description = inputAd.Description;
    ad.CategoryName = inputAd.CategoryName;
    ad.Price = inputAd.Price;
    ad.Type = inputAd.Type;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE item by ID
ads.MapDelete("/{id}", async (int id, AdDB db) =>
{
    if (await db.Ads.FindAsync(id) is Ad todo)
    {
        db.Ads.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.UseStaticFiles();
app.Run();
