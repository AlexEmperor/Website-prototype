using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;
using WEBtest;
using WEBtest.Db;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Db.Repositories;
using WEBTest.Db;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

string connection = builder.Configuration.GetConnectionString("WebTestConnection")!;

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "WEBTest2"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddTransient<IComparisonsRepository, ComparisonsDbRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
//builder.Services.AddTransient<PicturesDbRepository>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection));
builder.Services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));

builder.Services.AddIdentity<UserDTO, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.LoginPath = "/Account/Autorization";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

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
    context.Database.Migrate();
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

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserDTO>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    IdentityInitializer.Inititalize(userManager, roleManager);
}

app.Run();
