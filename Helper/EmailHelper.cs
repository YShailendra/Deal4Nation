using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Products.Helper
{
    public static class EmailHelper
    {

        public static bool SendMail(string to, string messageBody, string subject)
        {
            bool isResult = false;
            try
            {
                // MailMessage mail = new MailMessage("prateek22elinfinito@gmail.com", to);
                // SmtpClient client = new SmtpClient();

                // client.Port = 587;
                // client.Host = "smtp.gmail.com";
                // client.EnableSsl = true;
                // client.Timeout = 10000;
                // // client.DeliveryMethod = SmtpDeliveryMethod.Network;
                // // client.UseDefaultCredentials = false;

                // mail.Subject = subject;
                // mail.Body = messageBody;
                //  client.Credentials = new System.Net.NetworkCredential("prateek22elinfinito@gmail.com", "Elinfinito@22");
                // client.Send(mail);
                // isResult = true;
                String FROM = "prateek@elinfinitoindia.in";
                String FROMNAME = "Deals Locker App";

                // Replace recipient@example.com with a "To" address. If your account 
                // is still in the sandbox, this address must be verified.
                String TO = "prateek@elinfinitoindia.in";

                // Replace smtp_username with your Amazon SES SMTP user name.
                String SMTP_USERNAME = "AKIAU2YKI5JTWJFQV4UU";

                // Replace smtp_password with your Amazon SES SMTP user name.
                String SMTP_PASSWORD = "BOn1TqRjyFmu6Rbj7lIs721Bu9Kfza2byWFarOtmwlnJ";

                // (Optional) the name of a configuration set to use for this message.
                // If you comment out this line, you also need to remove or comment out
                // the "X-SES-CONFIGURATION-SET" header below.
                // String CONFIGSET = "ConfigSet";

                // If you're using Amazon SES in a region other than US West (Oregon), 
                // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                // endpoint in the appropriate AWS Region.
                String HOST = "email-smtp.us-east-1.amazonaws.com";

                // The port you will connect to on the Amazon SES SMTP endpoint. We
                // are choosing port 587 because we will use STARTTLS to encrypt
                // the connection.
                int PORT = 587;

                // The subject line of the email
                String SUBJECT =
                    "OTP to reset password ";

                // The body of the email
                String BODY =
                    "<h1>Deals Locker App</h1>" +
                    "<p>Please use this "  + messageBody +
                    "to reset your password.</p>" + "Or click on the below link" + 
                    "https://dealslocker.com/forgotpassword/"+ messageBody;

                // Create and build a new MailMessage object
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                // Comment or delete the next line if you are not using a configuration set
                // message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
                {
                    // Pass SMTP credentials
                    client.Credentials =
                        new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    // Try to send the message. Show status in console.
                    try
                    {
                        Console.WriteLine("Attempting to send email...");
                        client.Send(message);
                        Console.WriteLine("Email sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                //write exception log
                Console.WriteLine("error while sending the mail="+ex);
            }
            return isResult;
        }
    }
}
