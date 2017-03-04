
// You will need Visual Studio 2010 or later with C#
// Microsoft ASP.NET MVC 4 (https://www.asp.net/web-api)
// Internet Information Services (IIS) 7
// Create a new  ASP.NET 4 Web Application using the Web API template
// Add the following code in a new Controller called InboundMessagesController in the Controllers folder.
// Compile the solution and deploy the project to IIS7 on an internet-connected server
using System;
using System.Web.Http;

namespace PushNotificationsWebAPI.Controllers
{
    public class InboundMessagesController : ApiController
    {
        public void Post(InboundMessage inboundMessage)
        {
            // do something with the inboundMessage that you have just received
            System.Diagnostics.Trace.TraceInformation($"Message Received!");
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