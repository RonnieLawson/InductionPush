using System.Web.Http;

namespace InductionPush.Controllers
{
    public class AccountEventController : ApiController
    {
        private readonly EmailSender _emailSender = new EmailSender();

        [HttpPost]
        public async void Post()

        {
            System.Diagnostics.Trace.TraceInformation($"Unhandled Event Received");
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);
        }

        public async void MessageReceived(string notificationType, string id, string originator, string recipient, string body, string type, string receivedAt)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);
            System.Diagnostics.Trace.TraceInformation($"Message Received from {originator}");
            System.Diagnostics.Trace.TraceInformation($"Sending email");

            _emailSender.SendEmail($"Message Received", $"Message Received {receivedAt}: {body}");
        }

        public async void MessageEvent(string notificationType, string id, string eventType, string occurredAt)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);

            System.Diagnostics.Trace.TraceInformation($"Message Event: {eventType}");
            System.Diagnostics.Trace.TraceInformation($"Sending email");

            _emailSender.SendEmail($"Message Event", $"Message Event Received {eventType} at {occurredAt}");
        }

        public async void MessageError(string notificationType, string id, string errorType, string occurredAt, string detail)
        {
            var raw = await RawContentReader.Read(Request);
            System.Diagnostics.Trace.TraceInformation(raw);

            System.Diagnostics.Trace.TraceInformation($"Message Error: {errorType}");
            System.Diagnostics.Trace.TraceInformation($"Sending email");

            _emailSender.SendEmail($"Message Error", $"Message Error Received {errorType} at {occurredAt}");
        }
    }
}