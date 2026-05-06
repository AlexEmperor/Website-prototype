using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class OrderFurnitureViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Описание товара", Prompt = "Описание")]
        [Required(ErrorMessage = "Не указано описание товара")]
        public string Description { get; set; }

        [Display(Name = "Цена товара", Prompt = "Цена")]
        [Required(ErrorMessage = "Не указано цена товара")]
        public decimal Price { get; set; }

        [Display(Name = "Площадка", Prompt = "Где заказано")]
        [Required(ErrorMessage = "Не указано где заказан товар")]
        public string OrderPlace { get; set; }


        public int Volume { get; set; }

        public string Provider { get; set; } = "";

        public DateTime OrderCreationDateTime { get; set; }
        public DateTime OrderDeliveryDateTime { get; set; }


        [Required(ErrorMessage = "Не указано где заказан товар")]
        // Навигационные свойства
        public int? FurnituresId { get; set; }

       // [ForeignKey(nameof(Furniture))]
        public Furniture? Furnitures { get; set; }

        public ICollection<Furniture> FurnituraList { get; set; } = new List<Furniture>();

        // public ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();




        // public ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();
        // public List<Product>? Products { get; set; }
        // public List<OrderFurniture>? OrderFurnitures { get; set; } // Many-to-Many
        //  public List<OrderFurnitureItem> OrderItems { get; set; } = [];


    }
}
