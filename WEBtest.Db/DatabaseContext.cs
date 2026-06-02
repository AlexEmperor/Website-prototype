using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WEBtest.Db.Models;

namespace WEBTest.Db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Database.EnsureDeleted(); // проверка существования БД, если она есть - удаляет БД
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
        public DbSet<Category> Categories { get; set; }                  //Категории товаров

        public DbSet<Furniture> Furniture { get; set; }                  //Фурнитура
        public DbSet<OrderFurniture> FurnitureOrders { get; set; }       // Заказы фурнитур


        public DbSet<OrderFurnitureItem> OrderFurnitureItems { get; set; }


        public DbSet<Registration> Registration { get; set; } = null!;   // Пользователи прошедшие регистрацию


        public DbSet<Pictures> Pictures { get; set; } = null!;           // Картинки сайта



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



    //        modelBuilder.Entity<Product>()
    //.HasMany(p => p.FurnituraList)
    //.WithOne() // 👈 Пусто, т.к. в Furnitura нет навигации обратно
    //.HasForeignKey(f => f.ProductId)
    //.OnDelete(DeleteBehavior.Cascade);



            //    modelBuilder.Entity<Order>()
            //.HasOne(o => o.DeliveryUser)
            //.WithMany() // или .WithMany(u => u.Orders), если есть обратная навигация
            //.HasForeignKey("DeliveryUserId") // имя теневого свойства
            //.IsRequired(false); // 👈 Делаем связь необязательной

            //            base.OnModelCreating(modelBuilder);


            //            // ===== Категории =====
            //            modelBuilder.Entity<Category>().HasData(
            //                new { Id = 1, CategoryName = "Сережки" },
            //                new { Id = 2, CategoryName = "Стройка" },
            //                new { Id = 3, CategoryName = "Брелки" },
            //                new { Id = 4, CategoryName = "Заколки" },
            //                new { Id = 5, CategoryName = "Игрушки" },
            //                new { Id = 6, CategoryName = "Вязание" },
            //                new { Id = 7, CategoryName = "Аксессуары" },
            //                new { Id = 8, CategoryName = "Брошь" },
            //                new { Id = 9, CategoryName = "Браслеты" },
            //                new { Id = 10, CategoryName = "Электроника" },
            //                new { Id = 11, CategoryName = "Подвески" },
            //                new { Id = 12, CategoryName = "Комплекты" },
            //                new { Id = 13, CategoryName = "Интерьер" },
            //                new { Id = 14, CategoryName = "Кольца" },
            //                new { Id = 15, CategoryName = "Ёлочные игрушки" },
            //                new { Id = 16, CategoryName = "Романтика 8 марта" }

            //            );
            //            // Furniture
            //            modelBuilder.Entity<Furniture>().HasData(
            //    new { Id = 1, Name = "Пластик белый", Description = "PED-G", Price = 918m, OrderPlace = "WB" },
            //    new { Id = 2, Name = "Газлифт 100N", Description = "Газлифт мебельный", Price = 300m, OrderPlace = "China" },
            //    new { Id = 3, Name = "Направляющие шариковые", Description = "Направляющие для ящиков", Price = 450m, OrderPlace = "Poland" }
            //);

            //            modelBuilder.Entity<OrderFurniture>().HasData(
            //                new { Id = 1, Price = 15000m, Provider = "Hettich", OrderCreationDateTime = new DateTime(2025, 1, 10), OrderDeliveryDateTime = new DateTime(2025, 1, 20) },
            //                new { Id = 2, Price = 8000m, Provider = "Blum", OrderCreationDateTime = new DateTime(2025, 2, 5), OrderDeliveryDateTime = new DateTime(2025, 2, 15) }
            //            );

            modelBuilder.Entity<OrderFurnitureItem>().HasKey(x => new { x.OrderFurnitureId, x.FurnitureId });

//            modelBuilder.Entity<OrderFurnitureItem>().HasData(
//                new { OrderFurnitureId = 1, FurnitureId = 1, Quantity = 20 },
//                new { OrderFurnitureId = 1, FurnitureId = 3, Quantity = 10 },
//                new { OrderFurnitureId = 2, FurnitureId = 2, Quantity = 15 }
//            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
