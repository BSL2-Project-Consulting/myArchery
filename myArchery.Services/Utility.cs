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
        public static List<T> CreateList<T>(params T[] elements)
        {
            return new List<T>(elements);
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

        public static bool SendEmail(string email, string message)
        {
            //MailMessage message1 = new MailMessage();
            //SmtpClient smtp = new SmtpClient();
            //message1.From = new MailAddress("myarchery.bslinz2@gmail.com");
            //message1.To.Add(new MailAddress(email));
            //message1.Subject = "Test";
            //message1.IsBodyHtml = false; //to make message body as html  
            //message1.Body = message;
            //smtp.Port = 465;
            //smtp.Host = "smtp.gmail.com"; //for gmail host  
            //smtp.EnableSsl = true;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Send(message1);


            MailSettings.SMTPServer = "smtp.gmail.com";
            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress("pqr@gmail.com");
            // Recipient e-mail address.
            Msg.To.Add("abc@gmail.com");
            Msg.CC.Add("zcd@gmail.com");
            Msg.Subject = "Timesheet Payment Instruction updated";
            Msg.IsBodyHtml = true;
            Msg.Body = message;
            NetworkCredential loginInfo = new NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["UserName"]), Convert.ToString(ConfigurationManager.AppSettings["Password"])); // password for connection smtp if u dont have have then pass blank

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = loginInfo;
            //smtp.EnableSsl = true;
            //No need for port
            //smtp.Host = ConfigurationManager.AppSettings["HostName"];
            //smtp.Port = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
            smtp.Send(Msg);

            return true;
        }
    }
}
