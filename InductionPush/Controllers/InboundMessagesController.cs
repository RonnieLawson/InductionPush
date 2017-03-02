using System.Net.Mail;
using InductionPush.Models;

namespace InductionPush.Controllers
{
    using System;
    using System.Web.Http;
    namespace PushNotificationsWebAPI.Controllers
    {
        public class InboundMessagesController : ApiController
        {
            [HttpPost]
            public void Post(InboundMessage inboundMessage)
            {
                // do something with the inboundMessage that you have just received

                SendConfirmation();
                //Utility.Log("Message Received");
                if(inboundMessage != null)
                    Console.WriteLine("Message Recieved: " + inboundMessage.MessageText);
                else
                {
                    Console.WriteLine("Message Recieved But invalid inbound message");
                }
            }

            private static void SendConfirmation()
            {

                SmtpClient client = new SmtpClient
                {
                    Port = 465,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("messageDispatcher@quiffco.com", "kxF22JKV"),
                    Host = "mail3.gridhost.co.uk"
                };
                MailMessage mail = new MailMessage
                {
                    To = { new MailAddress("quiffco@quiffco.com")},
                    Subject = "this is a test email.",
                    Body = "this is my test email body"
                };
                client.Send(mail);
            }
        }
        public class InboundMessage
        {
            public Guid Id { get; set; }
            public Guid MessageId { get; set; }
            public Guid AccountId { get; set; }
            public string MessageText { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public DateTime Now { get; set; }
        }
    }
}
