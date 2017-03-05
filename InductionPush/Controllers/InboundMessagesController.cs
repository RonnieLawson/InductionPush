﻿
// You will need Visual Studio 2010 or later with C#
// Microsoft ASP.NET MVC 4 (https://www.asp.net/web-api)
// Internet Information Services (IIS) 7
// Create a new  ASP.NET 4 Web Application using the Web API template
// Add the following code in a new Controller called InboundMessagesController in the Controllers folder.
// Compile the solution and deploy the project to IIS7 on an internet-connected server
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;
using InductionPush;

namespace PushNotificationsWebAPI.Controllers
{
    public class InboundMessagesController : ApiController
    {


        private readonly EmailSender _emailSender = new EmailSender();


        public void Post(InboundMessage inboundMessage)
        {
            if (inboundMessage == null)
            {
                System.Diagnostics.Trace.TraceInformation("Null Inbound Message");
                return;
            }

            System.Diagnostics.Trace.TraceInformation($"Message Received from {inboundMessage.From}");
            System.Diagnostics.Trace.TraceInformation($"Message Text: {inboundMessage.MessageText}");
            
            //var password = ConfigurationManager.AppSettings["EmailPassword"];

            //var password = Environment.GetEnvironmentVariable("APPSETTINGS_EmailPassword");

            // do something with the inboundMessage that you have just received
            System.Diagnostics.Trace.TraceInformation($"Sending email");
            Console.WriteLine("Sending Email");
            _emailSender.SendEmail($"Message Received from {inboundMessage.From}", inboundMessage.MessageText, inboundMessage.From);
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
    }
}