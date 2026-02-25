using Serilog;
using System.Numerics;
using WEBtest.Db.Interfaces;
using WEBtest.Db.Models;
using WEBtest.Interfaces;
using WEBtest.Models;

namespace WEBtest.Repositories
{

    public class InMemoryRegistrationRepository : IRegistrationRepository
    {
        private int _instanceCounter = 0;

        private readonly List<RegistrationViewModel> _registrations;
        public InMemoryRegistrationRepository()
        {
            _registrations =
            [
                new RegistrationViewModel(++_instanceCounter,"1", "1", "1", "1", "1", "1"),
                new RegistrationViewModel(++_instanceCounter,"1", "1", "1", "1", "1", "1"),
                new RegistrationViewModel(++_instanceCounter,"1", "1", "1", "1", "1", "1"),
            ];
        }

        public List<RegistrationViewModel> GetAll() => _registrations;
        public List<RegistrationViewModel> Search(string text)
        {
            var products = GetAll().Where(registration => registration.FirstName!.Contains(text, StringComparison.OrdinalIgnoreCase));

            return products.ToList() ?? [];
        }
        public RegistrationViewModel? TryGetById(int id) => _registrations.FirstOrDefault(product => product.ID == id);
      
        
        
        public void Add(int id, string login, string password, string confirmPassword, string phone, string firstName, string lastName)
        {
            var registration = new RegistrationViewModel(++_instanceCounter, login, password,confirmPassword, phone,  firstName,lastName);

            _registrations.Add(registration);
        }
        public void Add(RegistrationViewModel registration)
        {
            registration.ID = ++_instanceCounter;

            _registrations.Add(registration);
        }
        public void Delete(int registrationId)
        {
            var existingRegistration = TryGetById(registrationId);

            if (existingRegistration != null)
            {
                _registrations.Remove(existingRegistration);
            }
        }
        public void Update(RegistrationViewModel registration)
        {
            var excitingRegistration = TryGetById(registration.ID);

            if (excitingRegistration != null)
            {
                excitingRegistration.FirstName = registration.FirstName;
                excitingRegistration.LastName = registration.LastName;
                excitingRegistration.Login = registration.Login;
            }
        }

    }
}
