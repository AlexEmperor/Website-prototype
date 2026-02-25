using WEBtest.Db.Models;

namespace WEBtest.Db.Interfaces
{
    public interface IRegistrationsRepository
    {
        List<Registration> GetAll();
        Registration? TryGetById(int registrationId);
        void Add(Registration registration);
        void Delete(int registrationId);
        void Update(Registration registration);
       // List<Registration> Search(string text);

    }
}
