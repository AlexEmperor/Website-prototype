using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Models;

namespace WEBTest.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted(); // проверка существования БД, если она есть - удаляет БД
            //Database.EnsureCreated(); // проверка существования БД, если её нет - создаёт новую БД
            Database.Migrate();
        }

        //Доступ к таблицам
        public DbSet<Product> Products { get; set; }                     //Товары
        public DbSet<Cart> Carts { get; set; }                           //Корзина
        public DbSet<CartItem> CartItems { get; set; }                   //Лежит в Корзине
        public DbSet<Favourite> Favorites { get; set; } = null!;         //Избранное
        public DbSet<Comparison> Comparisons { get; set; } = null!;      //Сравнение
        public DbSet<Order> Orders { get; set; } = null!;                // Заказы
        public DbSet<DeliveryUser> DeliveryUsers { get; set; } = null!;  // Информация о пользователе заказа (Пользователи сделали заказ)
       
        
        
        public DbSet<Registration> Registration { get; set; } = null!;   // Пользователи прошедшие регистрацию
    }
}
