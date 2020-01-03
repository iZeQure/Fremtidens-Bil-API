using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("api/{controller}/{action}")]
    public class UserController : ControllerBase
    {
        //GET: api/User/id/1234567890
        [HttpGet("{id}")]
        [ActionName("id")]
        public string[] Get(string id)
        {
            UserRepository userRepository = new UserRepository();
            var user = userRepository.GetById(id);
            string[] userProps = new string[]
            {
                user.Id,
                user.UserName,
                user.FirstName,
                user.LastName,
                user.Contact.PhoneNumber,
                user.Credential.MailAddress,
            };

            return userProps;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ActionName("delete")]
        public void Delete(int id)
        {
        }

        //GET: api/user/check/1234567890
        [HttpGet("{id}")]
        [ActionName("check")]
        public bool CheckUserExist(string id)
        {
            UserRepository ur = new UserRepository();
            User u = new User()
            {
                Id = id
            };

            return ur.CheckUserExists(u);
        }
    }
}
