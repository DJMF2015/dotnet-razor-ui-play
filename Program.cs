using ContosoPizza.Data;
using ContosoPizza.Services;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args); // this is the entry point for the application
builder.Services.AddScoped<PizzaService>(); // this is the dependency injection for the PizzaService class
// Add services to the container.
builder.Services.AddRazorPages(); // this is the dependency injection for the RazorPages
// this is the dependency injection for the PizzaContext class
builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite("Data Source=ContosoPizza.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
