﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Objects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("{controller}/{action}")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        //GET: credential/authcredential/mail/password
        [EnableCors("AngularProject")]
        [HttpGet("{mSecret}/{pSecret}")]
        [ActionName("authCredential")]
        public bool ValidateCredential(string mSecret, string pSecret)
        {
            UserRepository userRepository = new UserRepository();

            Credential credential = new Credential()
            {
                MailAddress = mSecret,
                Password = pSecret
            };

            return userRepository.AuthenticateCredentials(credential);
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