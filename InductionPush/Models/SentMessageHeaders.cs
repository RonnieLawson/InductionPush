using System;
using RestSharp.Deserializers;

namespace InductionPush.Models
{
    [DeserializeAs(Name = "messageheaders")]
    public class SentMessageHeaders
    {
        public Guid BatchId { get; set; }
        public MessageHeader MessageHeader { get; set; }
    }
}