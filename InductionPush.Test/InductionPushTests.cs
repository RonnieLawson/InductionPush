using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace InductionPush.Test
{
    [TestFixture]
    public class InductionPushTests
    {
        public class GivenAnEmailSender
        {
            private EmailSender _emailSender;

            [OneTimeSetUp]
            public void WhenCallingSend()
            {
                _emailSender = new EmailSender();
            }

            [Test]
            public void ThenTheEmailIsSent()
            {
                var subject = "Test Subject";
                var body = "test body";


                _emailSender.SendEmail(subject, body, "");
            }
        }

        /*[TestFixture]
        public class GIvenAnXmlDecoder
        {
            private InboundMessage _inboundMessage;

            [OneTimeSetUp]
            public void WhenDeserializingTheResponse()
            {
                string content = "    <InboundMessage><Id>6eb2a830-595b-42e5-99a3-57d87e63db36</Id><MessageId>6eb2a830-595b-42e5-99a3-57d87e63db36</MessageId><AccountId>6eb2a830-595b-42e5-99a3-57d87e63db36</AccountId><MessageText>Hello</MessageText><From>07590360247</From><To>07422128264</To></InboundMessage>";

                var xmlDoc = new XmlDocument();

                XmlReader xmlReader = new DataTextReader();

                xmlDoc.Load();
                using ()
                {
                    InboundMessage obj = new XmlSerializer(typeof(InboundMessage)).Deserialize(,);
                    myObject scp = (myObject)obj;
                }
            
            var restResponse = new RestResponse {Content = content};
                _inboundMessage = xml.Deserialize<MessageInboxResponse>(restResponse);
            }

            [Test]
            public void ThenTheFirstMessageHasTheCorrectId()
            {
                Assert.That(_inboundMessage.MessageHeaders[0].Id.ToString(), Is.EqualTo("11483b43-072a-418a-b59c-d0261c63fc56"));
            }

            [Test]
            public void ThenTheMessageHeadersListIsPopulatedWithTheCorrectCount()
            {
                Assert.That(_inboundMessage.MessageHeaders.Count, Is.EqualTo(2));
            }

            [Test]
            public void ThenTheMessageHeadersListIsPopulated()
            {
                Assert.That(_inboundMessage.MessageHeaders, Is.Not.Null);
            }

            [Test]
            public void ThenTheMessageInboxResponseTotalCountIsCorrect()
            {
                Assert.That(_inboundMessage.TotalCount, Is.EqualTo(2));
            }

            [Test]
            public void ThenTheMessageInboxResponseCountIsCorrect()
            {
                Assert.That(_inboundMessage.Count, Is.EqualTo(2));
            }

            [Test]
            public void ThenTheMessageInboxResponseIsPopulated()
            {
                Assert.That(_inboundMessage, Is.Not.Null);
            }
        }*/
    }
}