using System.ComponentModel.DataAnnotations;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class HomeViewModel
    {

        public List<ProductViewModel> Products { get; set; } = default!;
        public List<PicturesViewModel> Pictures { get; set; } = default!;

    }
}
