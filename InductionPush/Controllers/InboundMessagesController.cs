using RestClient.Clients;
using RestClient.Models;

namespace InductionPush.Controllers
{
    using System;
    using System.Web.Http;
    namespace PushNotificationsWebAPI.Controllers
    {
        public class InboundMessagesController : ApiController
        {
            public void Post(InboundMessage inboundMessage)
            {
                // do something with the inboundMessage that you have just received

                SendConfirmation();
                Utility.Log("Message Received");
            }

            private static void SendConfirmation()
            {
                var restAuthenticator = new RestAuthenticator("https://api.esendex.com", "/v1.0/session/constructor", "Ronnie.Lawson+Induction@esendex.com",
                    Utility.GetSecret("password"));
                var messageSender = new MessageSender(@"/v1.0/messagedispatcher", restAuthenticator, "EX0224195")
                {
                    MessageToSend = new Message("07590360247", "Message received by push notifier")
                };
                var result = messageSender.Execute();
                Utility.Log("send status: " + result);
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
