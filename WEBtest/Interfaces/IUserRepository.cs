using WEBtest.Areas.Admin.Models;
using WEBtest.Models;

namespace WEBtest.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? TryGetByLogin(string login);
        List<User> GetAll();
        User? TryGetById(Guid userId);
        void Delete(Guid userId);
        void Update(User user);
        void ChangePassword(string login, string newPassword);
        void ChangeRole(string login, Role? newRole);
    }
}
