using Microsoft.EntityFrameworkCore;
using TodoApi_MinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Add services Dependency Injection here (like AddService methods)

builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseInMemoryDatabase("DB_TODO"));

var app = builder.Build();

// Configure pipeline here (like UseMethod/UseAuthentication/UseAuthorization)

app.MapGet("/TodoItem", async (TodoDbContext _db) => 
    await _db.Todos.ToListAsync());

app.MapGet("/TodoItem/{id}", async (TodoDbContext _db, int id) =>
    await _db.Todos.FindAsync(id));

app.MapPost("/TodoItem", async (TodoDbContext _db, TodoItem todo) =>
{
    _db.Todos.Add(todo);
    await _db.SaveChangesAsync();
    return Results.Created($"/TodoItem{todo.Id}", todo);
});

app.MapPut("/TodoItem/{id}", async (TodoDbContext _db, int id, TodoItem todoUpdate) =>
{
    var todoItem = await _db.Todos.FindAsync(id);
    if (todoItem == null) return Results.NotFound();
    todoItem.Name = todoUpdate.Name;
    todoItem.IsCompleted = todoUpdate.IsCompleted;
    await _db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/TodoItem/{id}", async (TodoDbContext _db, int id) =>
{
    if (await _db.Todos.FindAsync(id) is TodoItem todoItem)
    {
        _db.Todos.Remove(todoItem);
        await _db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.Run();
