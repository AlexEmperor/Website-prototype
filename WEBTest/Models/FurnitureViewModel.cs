using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using WEBtest.Db.Models;

namespace WEBtest.Models
{
    public class FurnitureViewModel
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Наименование товара", Prompt = "Наименование товара")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string OrderPlace { get; set; }
        //////////////////////////////////////////
        public int HardNumber { get; set; }

        public int Quantity { get; set; }



    }
}
