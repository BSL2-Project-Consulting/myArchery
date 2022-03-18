using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class Utility
    {
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

        public static bool SendEmail(string email, string message)
        {
            MailMessage message1 = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message1.From = new MailAddress("myarchery.bslinz2@gmail.com");
            message1.To.Add(new MailAddress(email));
            message1.Subject = "Test";
            message1.IsBodyHtml = false; //to make message body as html  
            message1.Body = message;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("myarchery.bslinz2@gmail.com", "bs-linz2-myarchery");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message1);

            Console.WriteLine("---- Email sent");

            return true;
        }
    }
}
