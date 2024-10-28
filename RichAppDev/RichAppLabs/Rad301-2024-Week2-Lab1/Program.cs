using Microsoft.EntityFrameworkCore;
using Rad301_2024_Week2_Lab1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

var todoItems = app.MapGroup("/todoitems");

// GET all items
todoItems.MapGet("/", async (TodoDB db) =>
    await db.Todos.ToListAsync());

// GET completed items
todoItems.MapGet("/complete", async (TodoDB db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

// GET item by ID
todoItems.MapGet("/{id}", async (int id, TodoDB db) =>
    await db.Todos.FindAsync(id) is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());

// GET New endpoint to search by priority
todoItems.MapGet("/priority/{priority}", async (int priority, TodoDB db) =>
    await db.Todos.Where(t => t.Priority == priority).ToListAsync());

// POST new item
todoItems.MapPost("/", async (Todo todo, TodoDB db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

// PUT update item by ID
todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDB db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    todo.Priority = inputTodo.Priority;  // Update Priority

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE item by ID
todoItems.MapDelete("/{id}", async (int id, TodoDB db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
