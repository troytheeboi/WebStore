using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using WebStore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
var constring = builder.Configuration.GetConnectionString("DefaultConnection");
// Register MyDbContext as a service
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(constring)
);

builder.Services.AddRazorPages();


var app = builder.Build();

app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


app.Run();
