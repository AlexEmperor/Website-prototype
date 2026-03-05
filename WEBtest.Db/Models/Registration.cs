using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WEBtest.Db.Models
{
    public class Registration  //Класс регистрация
    {
        //[Key]
        public int Id { get; set; }  // Первичный ключ

        public string Login { get; set; }                         //Логин
        public string Password { get; set; }                      //Пароль
        public string ConfirmPassword { get; set; }               //Подтверждение пароля

        public string Phone { get; set; }

        public string FirstName { get; set;}


        public string LastName { get; set; }

        public string Role { get; set; }

       // public Role? Role { get; set; }


        //public string LastName { get; set; }

        //registration.Id = Guid.NewGuid();
        //registration.CreationDateTime = DateTime.Now;   // Время регистрации нового пользователя

    }
}
