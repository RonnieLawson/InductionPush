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
                string subject = "Test Subject";
                string body = "test body";

                _emailSender.SendEmail(subject, body);
            }
        }
    }
}