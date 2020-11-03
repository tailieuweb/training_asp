using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Services
{
    static class EmailConfirmation
    {
        public static async Task<bool> SendEmailToUser(string toEmail,string url)
        {
            bool result = true;
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Email Verification", "doanhongthang.tdc2018@gmail.com"));
                message.To.Add(new MailboxAddress("Dear you", toEmail));
                message.Subject = "Confirm Email To Go Demo";
                message.Body = new TextPart("plain") { Text = $"Click to {url}" };
                using (var client = new SmtpClient())
                {
                  await client.ConnectAsync("smtp.gmail.com", 587, false);
                  await client.AuthenticateAsync("doanhongthang.tdc2018@gmail.com", "01686803643");
                  await client.SendAsync(message);
                  await client.DisconnectAsync(true);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
