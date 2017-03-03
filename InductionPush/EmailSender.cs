using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace InductionPush
{
    public class EmailSender
    {
        public void SendEmail(string subject, string body)
        {
            var message = new MailMessage("messageDispatch@quiffco.com", "quiffco@quiffco.com", subject, body);

            var password = ConfigurationManager.AppSettings["EmailPasword"];

            var client = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("messageDispatch@quiffco.com", password),
                Host = "mail3.gridhost.co.uk"
            };
            
            client.Send(message);
        }
    }
}