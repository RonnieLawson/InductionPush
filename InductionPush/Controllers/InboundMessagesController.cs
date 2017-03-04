
// You will need Visual Studio 2010 or later with C#
// Microsoft ASP.NET MVC 4 (https://www.asp.net/web-api)
// Internet Information Services (IIS) 7
// Create a new  ASP.NET 4 Web Application using the Web API template
// Add the following code in a new Controller called InboundMessagesController in the Controllers folder.
// Compile the solution and deploy the project to IIS7 on an internet-connected server
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;

namespace PushNotificationsWebAPI.Controllers
{
    public class InboundMessagesController : ApiController
    {
        //public void Post(InboundMessage inboundMessage)
        /*        public async void  Post(object postobject)
                {
                    // do something with the inboundMessage that you have just received
                    System.Diagnostics.Trace.TraceInformation($"Message Received!");

                    string raw = await RawContentReader.Read(this.Request);
                    System.Diagnostics.Trace.TraceInformation(raw);
                    //if (inboundMessage == null)
                   // {
                    //    System.Diagnostics.Trace.TraceInformation($"Message is null");
                   // }
                }*/

        public async void Post(InboundMessage inboundMessage)
        {
            // do something with the inboundMessage that you have just received
            System.Diagnostics.Trace.TraceInformation($"Message Received!");


            if (inboundMessage == null)
             {
                System.Diagnostics.Trace.TraceInformation($"Message is null");
             }

            string raw = await RawContentReader.Read(this.Request);
            System.Diagnostics.Trace.TraceInformation(raw);
        }
    }

    [XmlRoot]
    public class InboundMessage
    {
        [XmlElement]
        public Guid Id { get; set; }
        [XmlElement]
        public Guid MessageId { get; set; }
        [XmlElement]
        public Guid AccountId { get; set; }
        [XmlElement]
        public string MessageText { get; set; }
        [XmlElement]
        public string From { get; set; }
        [XmlElement]
        public string To { get; set; }
    }

    public class RawContentReader
    {
        public static async Task<string> Read(HttpRequestMessage req)
        {
            using (var contentStream = await req.Content.ReadAsStreamAsync())
            {
                contentStream.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(contentStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}