using Material.Blazor;
using Microsoft.EntityFrameworkCore;
using ToDoList;
using ToDoList.Components;
using ToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<ToDoContext>(opt => opt.UseSqlite($"Data Source={nameof(ToDoContext.ToDoDb)}"));

builder.Services.AddMBServices();

var app = builder.Build();

// Seed Database
await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ToDoContext>>();
await DatabaseUtility.EnsureDbCreatedAndSeedWithCountOfAsync(options, 5);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
