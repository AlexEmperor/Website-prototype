using WEBtest.Db.Models;
using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IRegistrationRepository
    {
        List<RegistrationViewModel> GetAll();
        RegistrationViewModel? TryGetById(int registrationId);
        void Add(RegistrationViewModel registration);
        void Delete(int registrationId);
        void Update(RegistrationViewModel registration);
        List<RegistrationViewModel> Search(string text);
    }
}
