using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBtest.Db.Interfaces;
using WEBtest.Interfaces;
using WEBtest.Helpers;
using WEBtest.Models;

namespace WEBtest.Views.Shared.Components.Favorite
{
    public class FavoriteViewComponent : ViewComponent
    {
        private readonly IFavouriteRepository _favoriteRepository;

        public FavoriteViewComponent(IFavouriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public string GetUserId()
        {
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public IViewComponentResult Invoke()
        {
            var favorite = _favoriteRepository.TryGetByUserId(GetUserId());
            // favorite уже FavouriteViewModel, считаем общее количество товаров
            var productsCount = favorite?.Quantity ?? 0;

            return View("Favorite", productsCount);
        }
    }
}
