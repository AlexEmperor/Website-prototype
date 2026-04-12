using System.ComponentModel.DataAnnotations;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class PicturesViewModel
    {
        public int Id { get; set; }  // Первичный ключ
        public byte[]? Point { get; set; }


#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<PicturesViewModel> Items { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<ProductViewModel> Items2 { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

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
