using Microsoft.EntityFrameworkCore;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{

    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Product> GetAll() =>
            _databaseContext.Products
                .Include(p => p.Category)
                .Include(p => p.FurnitureOrder)
                .ThenInclude(fo => fo.Furnitures)
                .ToList();

        public Product? TryGetById(int productId) =>
            _databaseContext.Products
                .Include(p => p.Category)
                .Include(p => p.FurnitureOrder)
                    .ThenInclude(fo => fo.Furnitures)
                .FirstOrDefault(product => product.Id == productId);
        public void Add(Product product)
        {
            _databaseContext.Products.Add(product);

            _databaseContext.SaveChanges();  // Сохраняем изменения в БД
        }

        public void Delete(int productId)
        {
            var existingProduct = TryGetById(productId);

            if (existingProduct != null)
            {
                _databaseContext.Products.Remove(existingProduct);
                _databaseContext.SaveChanges();  // Сохраняем изменения в БД
            }
        }

        public void Update(Product product)
        {
            var excitingProduct = TryGetById(product.Id);

            if (excitingProduct != null)
            {
                excitingProduct.Name = product.Name;
                excitingProduct.Cost = product.Cost;
                excitingProduct.Description = product.Description;
                excitingProduct.Article = product.Article;
                excitingProduct.Barcode = product.Barcode;
                excitingProduct.CategoryId = product.CategoryId;
                excitingProduct.FurnitureOrderId = product.FurnitureOrderId;
                excitingProduct.Storage_Ozon = product.Storage_Ozon;
                excitingProduct.Storage_FBS1 = product.Storage_FBS1;
                excitingProduct.Cost_price = product.Cost_price;
                excitingProduct.Costs_Ozon = product.Costs_Ozon;
                excitingProduct.Margin_FBO1 = product.Margin_FBO1;
                excitingProduct.Margin_FBS1 = product.Margin_FBS1;
               // excitingProduct.Jpeg = product.Jpeg;  // !!

                _databaseContext.SaveChanges();  // Сохраняем изменения в БД
            }
        }

        public List<Product> Search(string text)
        {
            return _databaseContext.Products
                .Include(p => p.Category)
                .Include(p => p.FurnitureOrder)
                    //.ThenInclude(fo => fo.Furnitures)
                .Where(product => product.Name!.Contains(text, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }

        public List<Category> GetAllCategories() => _databaseContext.Categories.ToList();

        public List<OrderFurniture> GetAllFurnitureOrders() => _databaseContext.FurnitureOrders.ToList();
    }
}
