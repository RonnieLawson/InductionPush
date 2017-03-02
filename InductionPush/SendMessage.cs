using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using InductionPush.Models;
using RestSharp;
using RestSharp.Serializers;


namespace InductionPush
{
    public class MessageSender
    {
        private readonly string _accountReference;

        public Message MessageToSend { get; set; }

        public SentMessageHeaders MessageSenderHeaders { get; set; }

        public MessageSender(string requestResource, RestAuthenticator authenticator, string accountReference)
        {
            _accountReference = accountReference;
            Authenticator = authenticator;
            RequestResource = requestResource;

        }

        public string RequestResource { get; set; }
        protected RestAuthenticator Authenticator;
        protected Uri ApiBaseUri = new Uri("https://api.esendex.com");

        public RestRequest SetupRequest(Method httpMethod, string resource)
        {
            var request = new RestRequest
            {
                Method = httpMethod,
                RequestFormat = DataFormat.Xml,
                XmlSerializer = new DotNetXmlSerializer()
            };

            request.AddHeader("Authorization", $"Basic {Authenticator.GetEncodedSession()}");
            request.Resource = resource;
            return request;
        }

        public void Authenticate()
        {
            if (!Authenticator.IsAuthenticated)
                Authenticator.Execute();
        }

        public RestSharp.RestClient SetupClient()
        {
            return new RestSharp.RestClient
            {
                BaseUrl = ApiBaseUri
            };
        }

        public  HttpStatusCode Execute()
        {
            Authenticate();

            var restClient = SetupClient();

            var request = SetupRequest(Method.POST, RequestResource);

            request.AddBody(new SendMessageBody(_accountReference, MessageToSend));

            var response = restClient.Execute<SentMessageHeaders>(request);

            if (response.StatusCode == HttpStatusCode.OK)
                MessageSenderHeaders = response.Data;
            return response.StatusCode;
        }
    }
}