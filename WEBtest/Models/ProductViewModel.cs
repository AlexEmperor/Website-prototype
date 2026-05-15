using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class ProductViewModel
    {


        public int Id { get; set; }

        [Display(Name = "Наименование товара", Prompt = "Наименование товара")]
        [Required(ErrorMessage = "Не указано наименование товара")]
        [DataType(DataType.Text)]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Наименование товара должно быть от {2} до {1} символов")]
        public string Name { get; set; }

        [Display(Name = "Цена, руб.", Prompt = "Цена, руб.")]
        [Required(ErrorMessage = "Не указана цена товара")]
        [Range(0, 1000000, ErrorMessage = "Цена товара должна быть в диапазоне от {1} до {2} рублей")]
        public decimal Cost { get; set; }

        [Display(Name = "Описание товара", Prompt = "Описание товара")]
        [MaxLength(4096, ErrorMessage = "Максимальная длина описания товара {1} символов")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }


        public byte[]? Jpeg { get; set; }   //Jpeg


        // [Required]
        public string? PhotoPath { get; set; } = "/img/product.png";
        public IFormFile? PhotoFile { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        public int? FurnitureOrderId { get; set; }

        public OrderFurniture? FurnitureOrder { get; set; }



        [Required]
        public string Article { get; set; }
       
        public string Barcode { get; set; }
        public string? BarcodeWB { get; set; }

        [Required]
        public int? Storage_Ozon { get; set; }

        [Required]
        public int? Storage_FBS1 { get; set; }

        [Required]
        public int? Cost_price { get; set; }

        [Required]
        public int? Costs_Ozon { get; set; }

        [Required]
        public int? Margin_FBO1 { get; set; }

        [Required]
        public int? Margin_FBS1 { get; set; }
        [Required]
        public int? Wasordered { get; set; } = 0;

        public int? Cancelled { get; set; } = 0;




        [ValidateNever]
        [AllowNull]
        //public List<CartItemViewModel> Items { get; set; }
        //public ICollection<Furniture> FurnituraList { get; set; } = new List<Furniture>();
       
        public List<Furniture> FurnituraList { get; set; } = new List<Furniture>();





        public ProductViewModel() { }



        public ProductViewModel(int id, string name, decimal cost, string? description, Byte[] jpeg)

        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
           // Jpeg = jpeg;
            PhotoPath = PhotoPath;
        }

    }
}
