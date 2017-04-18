using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using InductionPush.Models;

namespace InductionPush.Controllers
{
    public class InboundMessagesController : ApiController
    {
        private readonly EmailSender _emailSender = new EmailSender();
        
        public async Task<HttpResponseMessage> Post(InboundMessage inboundMessage)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);

            if (inboundMessage == null)
            {
                System.Diagnostics.Trace.TraceError("Null Inbound Message");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            System.Diagnostics.Trace.TraceInformation($"Message Received from {inboundMessage.From}");
            System.Diagnostics.Trace.TraceInformation($"Message Text: {inboundMessage.MessageText}");
            
            _emailSender.SendEmail($"Message Received from {inboundMessage.From}", inboundMessage.MessageText);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}