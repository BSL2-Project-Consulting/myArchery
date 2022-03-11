using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class Utility
    {
        public static void GenerateDummyValues()
        {
            GenerateDummyUser();
            GenerateDummyEvent();
        }

        private static void GenerateDummyUser()
        {
            if (!UserService.UserExists(username: "admin"))
            {
                UserService.AddUser("admin", "admin", "admin", "admin@myarchery.com", "admin".ConvertToSha256(), false);
            }
        }

        private static void GenerateDummyEvent()
        {
            throw new NotImplementedException();
        }

        private static void GenerateRoles()
        {
            throw new NotImplementedException();
        }

        public static string ConvertToSha256(this string pw)
        {
            string hashedPW = pw;

            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pw));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hashedPW = builder.ToString();
            }

            return hashedPW;

            
        }
    }
}
