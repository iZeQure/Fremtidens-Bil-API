using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Interfaces;
using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;
using Microsoft.AspNetCore.Cors;
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
        public JsonResult AuthenticateLoginCredential(User user)
        {
            UserRepository userRepository = new UserRepository();

            bool authLogin = userRepository.Authenticate_LoginCredentials(user);

            //return Ok(authLogin);
            return new JsonResult(authLogin);
        }

        //GET: credential/authaccount/mail
        [EnableCors("AngularProject")]
        [HttpGet("{mSecret}")]
        [ActionName("authAccount")]
        public bool AuthenticateAccountLock(string mSecret)
        {
            UserRepository userRepository = new UserRepository();

            User user = new User()
            {
                Credential = new Credential()
                {
                    MailAddress = mSecret
                }
            };

            user.Credential.MailAddress = mSecret;

            return userRepository.Authenticate_AccountLock(user);
        }

        //GET: credential/validate/mail
        [EnableCors("AngularProject")]
        [HttpGet("{mSecret}")]
        [ActionName("validate")]
        public bool CheckEmailAddressExists(string mSecret)
        {
            UserRepository userRepository = new UserRepository();

            User user = new User()
            {
                Credential = new Credential()
                {
                    MailAddress = mSecret
                }
            };

            return userRepository.Check_EmailAddressExists(user);
        }

        //GET: credential/credentialid/mail
        [EnableCors("AngularProject")]
        [HttpGet("{mailAddress}")]
        [ActionName("credentialid")]
        public ActionResult<User> GetUserCredentialIdByMailAddress(string mailAddress)
        {
            UserRepository userRepository = new UserRepository();

            User user = new User()
            {
                Credential = new Credential()
                {
                    MailAddress = mailAddress
                }
            };

            User userId = userRepository.Return_UserCredentialIdFromMailAddress(user);

            if (userId != null) return Ok(userId.Credential.Id);

            return NotFound();
        }
    }
}