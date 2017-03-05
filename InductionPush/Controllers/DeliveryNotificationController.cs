using System.Web.Http;
using InductionPush.Models;

namespace InductionPush.Controllers
{
    public class DeliveryNotificationController : ApiController
    {
        private readonly EmailSender _emailSender = new EmailSender();
        
        public async void Post(MessageDelivered messageDelivered)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);

            if (messageDelivered == null)
            {
                System.Diagnostics.Trace.TraceError("Null Message Delivered");
                return;
            }

            System.Diagnostics.Trace.TraceInformation($"Message Delivered from {messageDelivered.Id}");
            System.Diagnostics.Trace.TraceInformation($"Sending email");

            _emailSender.SendEmail($"Message Delivered", $"Message Delivered {messageDelivered.OccurredAt.ToShortDateString()} - {messageDelivered.OccurredAt.ToShortTimeString()}");           
        }
    }
}