using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("{controller}/{action}")]
    public class CredentialController : ControllerBase
    {
        //POST: credential/login
        [EnableCors("AngularProject")]
        [HttpPost]
        [ActionName("login")]
        public ActionResult<User> AuthenticateLoginCredential(User user)
        {
            UserRepository userRepository = new UserRepository();

            bool authLogin = userRepository.AuthenticateCredentials(user);

            return Ok(authLogin);
        }

        //GET: credential/authaccount/mail
        [EnableCors("AngularProject")]
        [HttpGet("{mSecret}")]
        [ActionName("authAccount")]
        public bool ValidateAccount(string mSecret)
        {
            UserRepository userRepository = new UserRepository();

            Credential credential = new Credential()
            {
                MailAddress = mSecret
            };

            return userRepository.AuthenticateAccount(credential);
        }

        //GET: credential/validate/mail
        [EnableCors("AngularProject")]
        [HttpGet("{mSecret}")]
        [ActionName("validate")]
        public bool CheckEmailExists(string mSecret)
        {
            UserRepository userRepository = new UserRepository();

            Credential credential = new Credential()
            {
                MailAddress = mSecret
            };

            return userRepository.CheckMailExists(credential);
        }
    }
}