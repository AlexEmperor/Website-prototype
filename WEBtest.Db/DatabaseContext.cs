using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Models;

namespace WEBTest.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.Migrate();
        }

        //Доступ к таблицам
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Favourite> Favorites { get; set; } = null!;
        public DbSet<Comparison> Comparisons { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<DeliveryUser> DeliveryUsers { get; set; } = null!;

    }
}
