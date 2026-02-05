using System.ComponentModel.DataAnnotations;

namespace WEBtest.Models
{
    public class DeliveryUserViewModel
    {

        public Guid Id { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Имя покупателя", Prompt = "Ваше имя")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Логин должен быть от {2} до {1} символов")]
        [Required(ErrorMessage = "Не указано имя покупателя")]
        public string Name { get; set; }


        [Display(Name = "Адрес доставки", Prompt = "Ваш адрес")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Логин должен быть от {2} до {1} символов")]
        [Required(ErrorMessage = "Не указан адрес доставки")]
        public string Address { get; set; }

        [Display(Name = "Телефон", Prompt = "Ваш телефон")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Логин должен быть от {2} до {1} символов")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Не указан телефон покупателя")]
        public string Phone { get; set; }

        [Display(Name = "Дата доставки")]
        //[DateRange]
        [Required(ErrorMessage = "Не указана дата доставки")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Комментарий", Prompt = "Ваш комментарий")]
        [MaxLength(512, ErrorMessage = "Максимальная длина комментария {1} символов")]
        [DataType(DataType.MultilineText)]
        public string? Comment { get; set; }

    }
}
