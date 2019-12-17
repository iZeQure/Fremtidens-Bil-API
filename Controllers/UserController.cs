using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public void Login()
        {
            IUserRepository userRepository = new UserRepository();            
        }
    }
}