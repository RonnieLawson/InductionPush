using System;

namespace InductionPush.Models
{
    public class MessageDelivered
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}