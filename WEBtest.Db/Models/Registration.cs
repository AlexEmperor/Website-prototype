using System.ComponentModel.DataAnnotations;

namespace WEBtest.Db.Models
{
    public class Registration  //Класс регистрация
    {
        [Key]
        public int Id { get; set; }  // Первичный ключ

        public string Login { get; set; }                         //Логин
        public string Password { get; set; }                      //Пароль

        public string Phone { get; set; }

        public string FirstName { get; set;}


        public string LastName { get; set; }
    }
}
