using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailServices
    {
        public static void SendEmail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("guna999nani@gmail.com", "CFPclass");
                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(email);
                msgObj.From = new MailAddress("guna999nani@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"www.FundooNotes.com/reset-password/{token}";
                client.Send(msgObj);
            }
        }
    }
}
