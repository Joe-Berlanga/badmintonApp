using Models.Connection;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models.User;
using Dapper;
using MySql.Data.MySqlClient;

namespace Services
{
    public class UserService
    {

        private MySqlConnection connection;

        public UserService()
        {
            var connection = new DBConnect("badapp").GetConnection();           
        }

        //public bool CreateUser(Login newUser)
        //{

        //    User user = new User();
        //    user.EmailAddress = newUser.EmailAddress;
        //    //user.PasswordEncrypted = EncryptPassword(newUser.Password);
        //    using (connection)
        //    {
        //    //    return connection.Execute("insert into user (username, emailaddress, password) values(@username, @emailaddress, @password)",
        //    //        new
        //    //        {
        //    //            password = newUser.PasswordEncrypted,
        //    //            username = newUser.UserName,
        //    //            emailaddress = newUser.EmailAddress
        //    //        }) > 0 ? true : false;
        //    //}
        //}

        //private string EncryptPassword(string password)
        //{
            
        //}

        private string CreateSalt()
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[10];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        //private string GenerateHash()
        //{

        //}

        public User Login(Login login)
        {
            using (connection)
            {
                return connection.QueryFirstOrDefault<User>("select *, password as encryptedpassword from user where emailaddress = @emailaddress", new { emailaddress = login.EmailAddress });
            }
        }

        public List<Priviledge> getPriviledges(int userId)
        {
            using (connection)
            {
                return connection.Query<Priviledge>("select * from priviledge where userid = @userid", new { userid = userId }).ToList();
            }
        }
    }
}
