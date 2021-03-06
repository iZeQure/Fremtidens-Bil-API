﻿using Fremtidens_Bil_API.Interfaces;
using Fremtidens_Bil_API.Models;
using Fremtidens_Bil_API.Objects;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;

namespace Fremtidens_Bil_API.Data
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Authenticate User Account
        /// </summary>
        /// <remarks>
        /// Takes the users credentials
        /// <see cref="Credential.MailAddress"/>
        /// and checks if the users mail is correct,
        /// and the user isn't locked in the database.
        /// </remarks>
        /// <param name="credential"></param>
        /// <seealso cref="Credential"/>
        /// <returns><see cref="bool"/></returns>
        public bool Authenticate_AccountLock(User user)
        {
            Database db = Database.Instance;
            using SqlConnection conn = db.GetConn();
            {
                conn.Open();

                using SqlCommand cmd = new SqlCommand("GET_AuthenticateAccountLock", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Mail", user.Credential.MailAddress)
                    .Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Bit)
                    .Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return (bool)Convert.ToBoolean(cmd.Parameters[1].Value);
            };
        }

        public void Authenticate_DisableAccount(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticate User Credentials
        /// </summary>
        /// <remarks>
        /// Takes the users credentials with 
        /// <see cref="Credential.MailAddress"/>
        /// <see cref="Credential.Password"/>
        /// then validates if they are found in the database,
        /// returns a bool on complete.
        /// </remarks>
        /// <param name="credential"></param>
        /// <seealso cref="Credential"/>
        /// <returns><see cref="bool"/></returns>
        public bool Authenticate_LoginCredentials(User user)
        {
            Database db = Database.Instance;
            try
            {
                using SqlConnection conn = db.GetConn();
                {
                    conn.Open();

                    using SqlCommand cmd = new SqlCommand("POST_AuthenticateLoginCredential", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Mail", user.Credential.MailAddress)
                        .Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@Password", user.Credential.Password)
                        .Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@ReturnValue", SqlDbType.Bit)
                        .Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    return (bool)Convert.ToBoolean(cmd.Parameters[2].Value);
                };
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ConfigurationErrorsException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks on if the user id exists
        /// </summary>
        /// <remarks>
        /// Finds the users 
        /// <see cref="BaseEntity.Id"/>
        /// and looks it up in the database,
        /// on result, returns bool.
        /// </remarks>
        /// <param name="user"></param>
        /// <seealso cref="User"/>
        /// <returns><see cref="bool"/></returns>
        public bool Check_CPRNumberExists(User user)
        {
            Database db = Database.Instance;
            using SqlConnection conn = db.GetConn();
            {
                conn.Open();

                // Get stored procedure to use.
                using SqlCommand cmd = new SqlCommand("GET_CheckCprNumberExists", conn)
                {
                    // Set command type as stored procedure.
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameter for stored procedure.
                cmd.Parameters.AddWithValue("@CprNumber", user.Id)
                    .Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Bit)
                    .Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery(); // Execute command query

                // Get return value from executed query.
                return (bool)Convert.ToBoolean(cmd.Parameters[1].Value);
            }
        }

        /// <summary>
        /// Checks on if the user email exists
        /// </summary>
        /// <remarks>
        /// Finds the users
        /// <see cref="Credential.MailAddress"/>
        /// and looks it up in the database,
        /// on result, returns bool.
        /// </remarks>
        /// <param name="credential"></param>
        /// <seealso cref="Credential"/>
        /// <returns><see cref="bool"/></returns>
        public bool Check_EmailAddressExists(User user)
        {
            Database db = Database.Instance;
            using SqlConnection conn = db.GetConn();
            {
                conn.Open();

                using SqlCommand cmd = new SqlCommand("GET_CheckEmailExists", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Mail", user.Credential.MailAddress)
                    .Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Bit)
                    .Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery(); // Execute command query

                // Get return value from executed query.
                return (bool)Convert.ToBoolean(cmd.Parameters[1].Value);
            }
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Return bool wether it succeeded or not. TRUE | FALSE
        /// </returns>
        public bool Create(User user)
        {
            // check if the user id already exists..
            bool userIdExists = Check_CPRNumberExists(user);
            bool credentialEmailExists = Check_EmailAddressExists(user);

            if (!userIdExists && !credentialEmailExists)
            {
                Database db = Database.Instance;

                using SqlConnection conn = db.GetConn();
                {
                    conn.Open();

                    using SqlCommand cmd = new SqlCommand("POST_User", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // User properties
                    cmd.Parameters.AddWithValue("@CprNumber", user.Id).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@UserName", user.UserName).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@LastName", user.LastName).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@FingerPrintId", user.FingerPrintId).Direction = ParameterDirection.Input;

                    // Contact properties
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.Contact.PhoneNumber).Direction = ParameterDirection.Input;

                    // Credential Properties
                    cmd.Parameters.AddWithValue("@MailAddress", user.Credential.MailAddress).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Password", user.Credential.Password).Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            return false;
        }

        public void Delete(User deleteEntity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a user by ID, 
        /// returns the whole user object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// <see cref="User"/>
        /// </returns>
        public User GetById(string id)
        {
            Database db = Database.Instance;
            User user = null;

            using SqlConnection conn = db.GetConn();
            {
                try
                {
                    conn.Open();

                    using SqlCommand cmd = new SqlCommand("GET_UserById", conn)
                    {
                        CommandType = CommandType.StoredProcedure
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

                            Contact = new Contact
                            {
                                Id = (string)sqlData[0],
                                PhoneNumber = (string)sqlData[4]
                            },

                            Credential = new Credential
                            {
                                Id = (string)sqlData[0],
                                MailAddress = (string)sqlData[5]
                            }
                        };
                    }
                    return user;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public User Return_FingerPrintIdFromUserId(User user)
        {
            throw new NotImplementedException();
        }

        public User Return_HeartBeatFromUserId(User user)
        {
            throw new NotImplementedException();
        }

        public User Return_UserCredentialIdFromMailAddress(User user)
        {
            Database db = Database.Instance;
            using SqlConnection conn = db.GetConn();
            conn.Open();

            using SqlCommand cmd = new SqlCommand("GET_UserIdFromMail", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@MailAddress", user.Credential.MailAddress).Direction = ParameterDirection.Input;

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string credentialId = reader.GetString(0);

                User returnUser = new User()
                {
                    Credential = new Credential()
                    {
                        Id = credentialId
                    }
                };

                return (User)returnUser;
            }

            return null;
        }

        public User Return_UserInformationByMailAddress(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User updateEntity)
        {
            throw new NotImplementedException();
        }

        public void Update_HeartBeatFromFingerPrintId(User user)
        {
            throw new NotImplementedException();
        }
    }
}
