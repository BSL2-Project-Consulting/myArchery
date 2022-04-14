using myArchery.Services.TmpClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace myArchery.Services
{
    public static class Utility
    {
        public static int ToInt(this string val)
        {
            return Convert.ToInt32(val);
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

        public static bool SendEmail(string email, string subject, string message)
        {            
            SmtpClient smtp = new();
            MailMessage message1 = new MailMessage
            {
                From = new MailAddress("myarchery.bslinz2@gmail.com"),            
                Subject = subject,
                IsBodyHtml = false, //to make message body as html  
                Body = message

            };
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("myarchery.bslinz2@gmail.com", "bs-linz2-myarchery");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            message1.To.Add(new MailAddress(email));
            smtp.Send(message1);

            Console.WriteLine("---- Email sent");

            return true;
        }

        public static string GetUserWithPointsAsJson(List<UsersWithPoints> users)
        {
            return JsonSerializer.Serialize(users);
        }

        public static string ConvertListToJson<T>(List<T> list)
        {
            return JsonSerializer.Serialize(list);
        }
    } 
}