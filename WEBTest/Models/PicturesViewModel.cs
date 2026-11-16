using System.ComponentModel.DataAnnotations;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class PicturesViewModel
    {
        public int Id { get; set; }  // Первичный ключ
        public byte[]? Point { get; set; }


        public List<PicturesViewModel> Items { get; set; }
        public List<ProductViewModel> Items2 { get; set; }

        /*
        public ProductViewModel() { }

        public ProductViewModel(int id, string name, decimal cost, string? description, Byte[] jpeg)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            Jpeg = jpeg;
            PhotoPath = PhotoPath;
        }
        */
    }
}
