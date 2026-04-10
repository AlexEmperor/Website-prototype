using System.ComponentModel.DataAnnotations;

namespace WEBtest.Models
{
    public enum OrderStatusViewModel
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Ожидает отгрузки")]
        Processed,

        [Display(Name = "Доставляется")]
        Delivering,

        [Display(Name = "Ожидает в ПВЗ")]
        Awaiting,

        [Display(Name = "Доставлен")]
        Delivered,

        [Display(Name = "Отменен")]
        Canceled
    }
}
