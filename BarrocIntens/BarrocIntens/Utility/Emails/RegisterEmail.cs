using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Utility.Emails
{
    internal class RegisterEmail
    {
        public RegisterEmail(string name, string email, string password)
        {
            // Validate the variables
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) )
            {
                throw new Exception(null);
            }

            // Get image
            MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes
                (AppDomain.CurrentDomain.BaseDirectory + "/Assets/Logo4_groot.png"));

            LinkedResource img = new LinkedResource(memoryStream, MediaTypeNames.Image.Png);
            img.ContentId = "Logo";

            // Create html body
            BodyBuilder bodyBuilder = new BodyBuilder();
            string templatePath = AppDomain.CurrentDomain.BaseDirectory + "/Utility/Emails/RegisterEmailTemplate.html";
            using (StreamReader SourceReader = System.IO.File.OpenText(templatePath))
            {
                bodyBuilder.HtmlBody = SourceReader.ReadToEnd();
            }

            // Create the actual mail 
            MailMessage mailMessage = new MailMessage(Sender.From, new MailAddress(email, name));
            mailMessage.Subject = "Register";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format(bodyBuilder.HtmlBody,
                img.ContentId,
                name,
                password);

            Sender.Email(mailMessage);
        }
    }
}
