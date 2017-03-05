using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace InductionPush
{
    public class EmailSender
    {
        public void SendEmail(string subject, string body, string password)
        {
            System.Diagnostics.Trace.TraceInformation("Creating message");
            var message = new MailMessage("messageDispatch@quiffco.com", "quiffco@quiffco.com", subject, body);
            System.Diagnostics.Trace.TraceInformation("Message created");


            System.Diagnostics.Trace.TraceInformation("Creating client");
            var client = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("messageDispatch@quiffco.com", password),
                Host = "mail3.gridhost.co.uk"
            };

            System.Diagnostics.Trace.TraceInformation("Client created");

            System.Diagnostics.Trace.TraceInformation("Sending message");
            client.Send(message);
            System.Diagnostics.Trace.TraceInformation("Message sent");
        }
    }
}