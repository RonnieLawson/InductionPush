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
            private readonly EmailSender _emailSender = new EmailSender();

            [HttpPost]
            public void Post(InboundMessage inboundMessage)
            {
                System.Diagnostics.Trace.TraceInformation("trace logging is working");
                Console.WriteLine("Message Received!");
                // do something with the inboundMessage that you have just received
                if (inboundMessage != null)
                {
                    Console.WriteLine("Sending Email");
                    _emailSender.SendEmail($"Message Received from {inboundMessage.From}", inboundMessage.MessageText);
                }
                //Utility.Log("Message Received");             
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
