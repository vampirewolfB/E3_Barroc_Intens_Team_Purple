using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Utility.Emails
{
    internal class Sender
    {
        public static void Email(MailMessage email)
        {
            // Add the send adress 
            email.From = new MailAddress(
                AppSettingLoader.Configuration["Email:SendMail"],
                AppSettingLoader.Configuration["Email:SendName"]
            );

            // Create the client to send emails,
            SmtpClient smtpClient = new SmtpClient(
                AppSettingLoader.Configuration["Email:Host"],
                AppSettingLoader.Configuration.GetValue<int>("Email:Port")
            )
            {
                Credentials = new NetworkCredential(
                    AppSettingLoader.Configuration["Email:UserName"],
                    AppSettingLoader.Configuration["Email:Password"]
                ),
                EnableSsl = AppSettingLoader.Configuration.GetValue<bool>("Email:EnableSsl")
            };

            // Send the email and after that dispose of it
            smtpClient.Send(email); 
            smtpClient.Dispose();
        }
    }
}
