using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Repositories;
using WEBtest.Interfaces;
using WEBtest.Repositories;
using WEBTest.Db;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("WebTestConnection");

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "WEBTest"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddTransient<IComparisonsRepository, ComparisonsDbRepository>();
builder.Services.AddSingleton<IRoleRepository, InMemoryRoleRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();

//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connection));
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("ru-RU")
    };
    options.DefaultRequestCulture = new RequestCulture("ru-RU");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    //context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseRequestLocalization();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
