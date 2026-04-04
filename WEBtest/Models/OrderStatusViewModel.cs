using System.ComponentModel.DataAnnotations;

namespace WEBtest.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "Доставляется")]
        Delivering,

        [Display(Name = "Доставлен")]
        Delivered,

        [Display(Name = "Отменен")]
        Canceled
    }
}
