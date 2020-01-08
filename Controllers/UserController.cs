using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("{controller}/{action}")]
    public class UserController : ControllerBase
    {
        //GET: user/id/1234567890
        [EnableCors("AngularProject")]
        [HttpGet("{id}")]
        [ActionName("id")]
        public ActionResult<User> Get(string id)
        {
            UserRepository userRepository = new UserRepository();
            try
            {
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

                if (userProps != null) return Ok(userProps);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NotFound();
        }

        [EnableCors("AngularProject")]
        [HttpPost]
        [ActionName("create")]
        public ActionResult<User> Create(User user)
        {
            UserRepository userRepository = new UserRepository();

            bool userExists = userRepository.Create(user);

            if (userExists != false)
            {
                return Ok(userExists);
            }
            else
            {
                return Conflict(userExists);
            }
        }

        // DELETE: ApiWithActions/5
        [EnableCors("AngularProject")]
        [HttpDelete("{id}")]
        [ActionName("delete")]
        public void Delete(int id)
        {
        }

        //GET: user/check/1234567890
        [EnableCors("AngularProject")]
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
