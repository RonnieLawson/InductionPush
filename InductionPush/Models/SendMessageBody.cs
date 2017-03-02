using System.Xml.Serialization;

namespace InductionPush.Models
{
    [XmlRoot("messages")]
    public class SendMessageBody
    {
        public SendMessageBody(string accountReference, Message message)
        {
            Accountreference = accountReference;
            Message = message;
        }

        [XmlElement("accountreference")]
        public string Accountreference { get; set; }
        [XmlElement("message")]
        public Message Message { get; set; }

        public SendMessageBody()
        { }
    }
}