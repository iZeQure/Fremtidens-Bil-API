using Fremtidens_Bil_API.Interfaces;
using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fremtidens_Bil_API.Data
{
    public class UserRepository : IUserRepository
    {
        public bool AuthenticateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserExists(User user)
        {
            throw new NotImplementedException();
        }

        public void Create(User createEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User deleteEntity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            Database _db = Database.Instance;
            List<User> users = new List<User>();

            using SqlConnection conn = _db.Connection;
            {
                conn.Open();

                using SqlCommand cmd = new SqlCommand("GETAllUsers", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                using SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    User u = new User()
                    {
                        Id = (string)dataReader[0],
                        UserName = (string)dataReader[1],
                        FirstName = (string)dataReader[2],
                        LastName = (string)dataReader[3],
                        FingerPrintId = (int)dataReader[4],
                        HeartRate = (int)dataReader[5],
                        AccountLocked = (bool)dataReader[6],
                        Contact = new Contact
                        {
                            Id = (string)dataReader[0],
                            PhoneNumber = (string)dataReader[7]
                        },
                        Credential = new Credential
                        {
                            Id = (string)dataReader[0],
                            MailAddress = (string)dataReader[8]
                        }
                    };

                    users.Add(u);
                }
                return users;
            }
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User updateEntity)
        {
            throw new NotImplementedException();
        }
    }
}
