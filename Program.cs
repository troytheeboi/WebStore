using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Org.BouncyCastle.Asn1.X509.SigI;
using WebStore;
using WebStore.Models;
using WebStore.Models.Bases;

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

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


// minimal API
/*app.MapGet("/hello/{name:alpha}", (string name) => $"Hello {name}!");
*/
//used to branch the pipeline // see MapWhen() and UseWhen() 
/*app.Map("/map2", HandleMapTest2);
*/

/*CustomerEntity person = new CustomerEntity("Mister","Test",970); 
*/

app.Use(async (HttpContext context, RequestDelegate next) =>
{
     Console.WriteLine(context.Request.Method.ToString() + context.Request.Body.ToString);
/*    await context.Response.WriteAsync("Middle1");
*/    /*    await context.Response.WriteAsJsonAsync(person);
    */
    await next(context);

});

//app.run always terminates pipeline
/*app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from 2nd delegate.");
});
*/

/*app.Use(async (HttpContext context, RequestDelegate next) =>
{

    await context.Response.WriteAsync("Middle2");
    await next(context);

});*/

static void HandleMapTest2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 2");
    });
}


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
