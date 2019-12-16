using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fremtidens_Bil_API
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckUserExists(User u);
        bool AuthenticateUser(User u);
        void Login(User u);
    }
}
