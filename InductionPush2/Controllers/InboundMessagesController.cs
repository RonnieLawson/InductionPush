using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InductionPush2.Controllers
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
                Console.WriteLine("Message Received");
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
