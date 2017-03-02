using System;
using RestSharp.Deserializers;

namespace InductionPush.Models
{
    [DeserializeAs(Name = "session")]
    public class AuthenticationResponse
    {
        [DeserializeAs(Name = "id")]
        public Guid id { get; set; }
    }
}