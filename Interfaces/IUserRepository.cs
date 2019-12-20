using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;

namespace Fremtidens_Bil_API.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckUserExists(User user);
        bool AuthenticateUser(User user);
        void Login(User user);
    }
}