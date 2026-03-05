using System.Data;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBTest.Db;

namespace WEBtest.Db.Repositories
{
    public class RegistrationDbRepository : IRegistrationsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RegistrationDbRepository(DatabaseContext databaseContext)  // подробнее
        {
            _databaseContext = databaseContext;
        }

        public List<Registration> GetAll() => _databaseContext.Registration.ToList();

        public Registration? TryGetById(int registrationId) =>
            _databaseContext.Registration.FirstOrDefault(registration => registration.Id == registrationId);

        public void Add(Registration registration)
        {

            //registration.Id = Guid.NewGuid();
            //registration.CreationDateTime = DateTime.Now;   // Время регистрации нового пользователя

            _databaseContext.Registration.Add(registration);

            _databaseContext.SaveChanges();  // Сохраняем изменения в БД
        }

        public void Delete(int registrationId)
        {
            var existingProduct = TryGetById(registrationId);

            if (existingProduct != null)
            {
                _databaseContext.Registration.Remove(existingProduct);
                _databaseContext.SaveChanges();  // Сохраняем изменения в БД
            }
        }

        public void Update(Registration registration)
        {
            var excitingRegistration = TryGetById(registration.Id);

            if (excitingRegistration != null)
            {
                excitingRegistration.Login = registration.Login;
                excitingRegistration.Password = registration.Password;
                excitingRegistration.LastName = registration.LastName;
                excitingRegistration.Role = registration.Role;

                _databaseContext.SaveChanges();  // Сохраняем изменения в БД
            }
        }

        //public List<Product> Search(string text)
        //{
        //    var registration = GetAll().Where(registration => registration.Login!.Contains(text, StringComparison.CurrentCultureIgnoreCase));

        //    return registration.ToList() ?? [];
        //}
    }
}
