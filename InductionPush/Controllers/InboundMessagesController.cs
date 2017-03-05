
// You will need Visual Studio 2010 or later with C#
// Microsoft ASP.NET MVC 4 (https://www.asp.net/web-api)
// Internet Information Services (IIS) 7
// Create a new  ASP.NET 4 Web Application using the Web API template
// Add the following code in a new Controller called InboundMessagesController in the Controllers folder.
// Compile the solution and deploy the project to IIS7 on an internet-connected server

using System;
using System.Configuration;
using System.Web.Http;

namespace InductionPush.Controllers
{
    public class InboundMessagesController : ApiController
    {
        private readonly EmailSender _emailSender = new EmailSender();
        
        public void Post(InboundMessage inboundMessage)
        {
            if (inboundMessage == null)
            {
                System.Diagnostics.Trace.TraceError("Null Inbound Message");
                return;
            }

            System.Diagnostics.Trace.TraceInformation($"Message Received from {inboundMessage.From}");
            System.Diagnostics.Trace.TraceInformation($"Message Text: {inboundMessage.MessageText}");
            
            var password = ConfigurationManager.AppSettings["EmailPassword"];
            System.Diagnostics.Trace.TraceInformation($"pword: {password}");

  
            System.Diagnostics.Trace.TraceInformation($"Sending email");

            _emailSender.SendEmail($"Message Received from {inboundMessage.From}", inboundMessage.MessageText, password);           
        }
    }
}