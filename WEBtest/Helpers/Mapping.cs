using WEBtest.Db.Models;
using WEBtest.Models;

namespace WEBtest.Helpers
{
    public static class Mapping
    {
        #region Picturs // Товар

        public static List<PicturesViewModel> ToPicturesViewModels(this List<Pictures> picturesDb)
        {
            var picturesViewModel = new List<PicturesViewModel>();

            foreach (var pictureDb in picturesDb)
            {
                picturesViewModel.Add(pictureDb.ToPictureViewModel());
            }

            return picturesViewModel;
        }

        public static PicturesViewModel ToPictureViewModel(this Pictures pictureDb)
        {
            return new PicturesViewModel()
            {
                Id = pictureDb.Id,
                Point = pictureDb.Point
            };
        }

        public static Pictures ToPictureViewModel(this PicturesViewModel picture)
        {
            return new Pictures
            {
                Id = picture.Id,
                Point = picture.Point
            };
        }

        #endregion

        #region Product // Товар

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
                Article = productDb.Article,
                Barcode = productDb.Barcode,
                CategoryId = productDb.CategoryId,
                Category = productDb.Category, // ← добавляем объект
                FurnitureOrderId = productDb.FurnitureOrderId,
                FurnitureOrder = productDb.FurnitureOrder, // ← добавляем объект
                PhotoPath = productDb.PhotoPath,
                Jpeg = productDb.Jpeg,
                Storage_Ozon = productDb.Storage_Ozon,
                Storage_FBS1 = productDb.Storage_FBS1,
                Cost_price = productDb.Cost_price,
                Costs_Ozon = productDb.Costs_Ozon,
                Margin_FBO1 = productDb.Margin_FBO1,
                Margin_FBS1 = productDb.Margin_FBS1,
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
                Jpeg = product.Jpeg,
                Article = product.Article,
                Barcode = product.Barcode,
                CategoryId = product.CategoryId,
                FurnitureOrderId = product.FurnitureOrderId,
                Storage_Ozon = product.Storage_Ozon,
                Storage_FBS1 = product.Storage_FBS1,
                Cost_price = product.Cost_price,
                Costs_Ozon = product.Costs_Ozon,
                Margin_FBO1 = product.Margin_FBO1,
                Margin_FBS1 = product.Margin_FBS1,
            };
        }
        #endregion

        #region Favorite


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
                DeliveryUser = orderDb.DeliveryUser.ToDeliveryUserViewModel(),
                CreationDateTime = orderDb.CreationDateTime,
                Status = (OrderStatusViewModel)orderDb.Status
            };
        }

        public static DeliveryUserViewModel ToDeliveryUserViewModel(this DeliveryUser deliveryUserDb)
        {
            return new DeliveryUserViewModel()
            {
                Id = deliveryUserDb.Id,
                Name = deliveryUserDb.Name,
                Login = deliveryUserDb.Email,
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
                Email = deliveryUser.Login,
                Address = deliveryUser.Address,
                Phone = deliveryUser.Phone,
                Date = DateTime.SpecifyKind(deliveryUser.Date, DateTimeKind.Utc),
                Comment = deliveryUser.Comment
            };
        }
        #endregion

        #region Registracion  //регистрация пользователей

        public static List<RegistrationViewModel> ToRegistrationViewModel(this List<Registration> registesDb)
        {
            var registrationViewModel = new List<RegistrationViewModel>();

            foreach (var registeDb in registesDb)
            {
                registrationViewModel.Add(registeDb.ToRegistrationViewModel());
            }
            return registrationViewModel;
        }

        public static RegistrationViewModel ToRegistrationViewModel(this Registration registeDb)
        {
            return new RegistrationViewModel()
            {
                Login = registeDb.Login,
                Password = registeDb.Password,
                Phone = registeDb.Phone,
                FirstName = registeDb.FirstName,
                LastName = registeDb.LastName,
                ConfirmPassword = registeDb.ConfirmPassword,
            };
        }

        public static Registration ToRegistrationDb(this Registration registra) // !!!!передача 
        {
            return new Registration()
            {
                Id = registra.Id,
                Login = registra.Login,
                Password = registra.Password,
                Phone = registra.Phone,
                FirstName = registra.FirstName,
                LastName = registra.LastName,
            };
        }
        /*
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
            */
        #endregion

    }
}
