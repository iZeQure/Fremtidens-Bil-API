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
        private Database _db = Database.Instance;

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
            List<User> users = new List<User>();

            using SqlConnection conn = _db.Connection;
            {
                conn.Open();

                using SqlCommand cmd = new SqlCommand("GETAllUsers", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                using SqlDataReader sqlData = cmd.ExecuteReader();

                while (sqlData.Read())
                {
                    User u = new User()
                    {
                        Id = (string)sqlData[0],
                        UserName = (string)sqlData[1],
                        FirstName = (string)sqlData[2],
                        LastName = (string)sqlData[3],
                        FingerPrintId = (int)sqlData[4],
                        HeartRate = (int)sqlData[5],
                        AccountLocked = (bool)sqlData[6],
                        Contact = new Contact
                        {
                            Id = (string)sqlData[0],
                            PhoneNumber = (string)sqlData[7]
                        },
                        Credential = new Credential
                        {
                            Id = (string)sqlData[0],
                            MailAddress = (string)sqlData[8]
                        }
                    };

                    users.Add(u);
                }
                return users;
            }
        }

        public User GetById(string id)
        {
            User user = null;

            using SqlConnection conn = _db.Connection;
            {
                conn.Open();

                using SqlCommand cmd = new SqlCommand("GETUserById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue($"@CprNumber", id);

                using SqlDataReader sqlData = cmd.ExecuteReader();

                while (sqlData.Read())
                {
                    user = new User()
                    {
                        Id = (string)sqlData[0],
                        UserName = (string)sqlData[1],
                        FirstName = (string)sqlData[2],
                        LastName = (string)sqlData[3],
                        FingerPrintId = (int)sqlData[4],
                        HeartRate = (int)sqlData[5],
                        AccountLocked = (bool)sqlData[6],
                        Contact = new Contact
                        {
                            Id = (string)sqlData[0],
                            PhoneNumber = (string)sqlData[7]
                        },
                        Credential = new Credential
                        {
                            Id = (string)sqlData[0],
                            MailAddress = (string)sqlData[8]
                        }
                    };
                }
                return user;
            }
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
