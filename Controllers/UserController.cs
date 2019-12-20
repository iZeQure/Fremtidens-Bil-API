﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fremtidens_Bil_API.Data;
using Fremtidens_Bil_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fremtidens_Bil_API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet(Name = "GetAll")]
        public List<User> GetAllUsers()
        {
            UserRepository _userRepository = new UserRepository();
            return _userRepository.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Debug.WriteLine("asd");
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
