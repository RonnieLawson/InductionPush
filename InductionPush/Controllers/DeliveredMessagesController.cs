using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using InductionPush.Models;

namespace InductionPush.Controllers
{
    public class DeliveredMessagesController : ApiController
    {
        private readonly EmailSender _emailSender = new EmailSender();
        
        public async Task<HttpResponseMessage> Post(MessageDelivered deliveredMessage)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);

            if (deliveredMessage == null)
            {
                System.Diagnostics.Trace.TraceError("Null Inbound Message");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            System.Diagnostics.Trace.TraceInformation($"Message {deliveredMessage.Id} was delivered at {deliveredMessage.OccurredAt.ToShortDateString()} : {deliveredMessage.OccurredAt.ToShortTimeString()}");

            _emailSender.SendEmail($"Message Delivered", $"Message {deliveredMessage.Id} was delivered at {deliveredMessage.OccurredAt.ToShortDateString()} : {deliveredMessage.OccurredAt.ToShortTimeString()}");

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}