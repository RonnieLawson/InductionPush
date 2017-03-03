using System.Configuration;
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
                System.Diagnostics.Trace.TraceInformation($"Message Received from {inboundMessage.From}");
                System.Diagnostics.Trace.TraceInformation($"Message Text: {inboundMessage.MessageText}");
                var password = ConfigurationManager.AppSettings["EmailPassword"];

                //var password = Environment.GetEnvironmentVariable("APPSETTINGS_EmailPassword");



                // do something with the inboundMessage that you have just received
                if (inboundMessage != null)
                {
                    System.Diagnostics.Trace.TraceInformation($"Sending email using password: {password}");
                    Console.WriteLine("Sending Email");
                    _emailSender.SendEmail($"Message Received from {inboundMessage.From}", inboundMessage.MessageText, password);
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
