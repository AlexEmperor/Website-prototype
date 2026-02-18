using WEBtest.Db.Models;
using WEBtest.Models;

namespace WEBtest.Helpers
{
    public static class Mapping
    {
        #region Productм // Товар
        public static List<ProductViewModel> ToProductViewModels(this List<Product> productsDb)
        {
            var productsViewModel = new List<ProductViewModel>();

            foreach (var productDb in productsDb)
            {
                productsViewModel.Add(productDb.ToProductViewModel());
            }

            return productsViewModel;
        }

        public static ProductViewModel ToProductViewModel(this Product productDb)
        {
            return new ProductViewModel()
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description,

               //PhotoPath = productDb.PhotoPath,
               // jpeg = productDb.jpeg,
            };
        }

        public static Product ToProductDb(this ProductViewModel product)  // передача в БД  Product
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                PhotoPath = product.PhotoPath,
                jpeg = product.japeg,
            };
        }
        #endregion

        #region Cart   // Корзина
        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDbItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();

            foreach (var cartDbItem in cartDbItems)
            {
                cartItemsViewModel.Add(cartDbItem.ToCartItemViewModel());
            }

            return cartItemsViewModel;
        }

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartDbItem)
        {
            return new CartItemViewModel()
            {
                Id = cartDbItem.Id,
                Product = cartDbItem.Product.ToProductViewModel(),
                Quantity = cartDbItem.Quantity,
            };
        }

        public static CartViewModel? ToCartViewModel(this Cart? cartDb)
        {
            return cartDb == null
                ? null
                : new CartViewModel()
                {
                    Id = cartDb.Id,
                    UserId = cartDb.UserId,
                    Items = cartDb.Items.ToCartItemViewModels(),
                };
        }
        #endregion

        #region Comparison  // Сравнение
        public static ComparisonViewModel? ToComparisonViewModel(this Comparison? comparisonDb)
        {
            return comparisonDb == null
                ? null
                : new ComparisonViewModel()
                {
                    Id = comparisonDb.Id,
                    UserId = comparisonDb.UserId,
                    Items = comparisonDb.Items.ToProductViewModels()
                };
        }
        #endregion

        #region Favorite // Избранное
        public static FavouriteViewModel? ToFavoriteViewModel(this Favourite? favoriteDb)
        {
            return favoriteDb == null
                ? null
                : new FavouriteViewModel()
                {
                    Id = favoriteDb.Id,
                    UserId = favoriteDb.UserId,
                    Items = favoriteDb.Items.ToProductViewModels()
                };
        }
        #endregion

        #region Order  //Заказы
        public static List<OrderViewModel> ToOrderViewModels(this List<Order> ordersDb)
        {
            var ordersViewModel = new List<OrderViewModel>();

            foreach (var orderDb in ordersDb)  // Вывод на панель Администратора текущие заказы
            {
                ordersViewModel.Add(orderDb.ToOrderViewModel());   // добавляем 
            }

            return ordersViewModel;
        }

        public static OrderViewModel ToOrderViewModel(this Order orderDb) // !!!!передача 
        {
            return new OrderViewModel()
            {
                Id = orderDb.Id,
                UserId = orderDb.UserId,
                Items = orderDb.Items.ToCartItemViewModels(),
             //   DeliveryUser = orderDb.DeliveryUser.ToDeliveryUserViewModel(),
                CreationDateTime = orderDb.CreationDateTime,
                Status = (OrderStatusViewModel)orderDb.Status,
            };
        }

        public static DeliveryUserViewModel ToDeliveryUserViewModel(this DeliveryUser deliveryUserDb)  
        {
            return new DeliveryUserViewModel()
            {
                Id = deliveryUserDb.Id,
                Name = deliveryUserDb.Name,
                Address = deliveryUserDb.Address,
                Phone = deliveryUserDb.Phone,
                Date = DateTime.SpecifyKind(deliveryUserDb.Date, DateTimeKind.Utc),
                Comment = deliveryUserDb.Comment
            };
        }

        public static DeliveryUser ToDeliveryUserDb(this DeliveryUserViewModel deliveryUser)  // получение данных при "Оформление заказа"
        {
            return new DeliveryUser()
            {
                Id = deliveryUser.Id,
                Name = deliveryUser.Name,
                Address = deliveryUser.Address,
                Phone = deliveryUser.Phone,
                Date = DateTime.SpecifyKind(deliveryUser.Date, DateTimeKind.Utc),
                Comment = deliveryUser.Comment
            };
        }
        #endregion
    }
}
