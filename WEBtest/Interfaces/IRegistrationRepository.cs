using WEBtest.Db.Models;
using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IRegistrationRepository
    {
        List<Registration> GetAll();
        Registration? TryGetById(int registrationId);
        void Add(Registration registration);
        void Delete(int registrationId);
        void Update(Registration registration);
        List<Registration> Search(string text);
    }
}
