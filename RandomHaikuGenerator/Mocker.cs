using System;
using System.Collections.Generic;
using System.Text;

namespace RandomHaikuGenerator
{
    public interface IEmail {
        public void SendMail(string to, string sender, string body);
    }
    public class EmailSender
    {
        private IEmail _email;

        public EmailSender(IEmail email)
        {
            this._email = email;
        }
        public void NotifyItWasSent(string toAdress, string numOrder)
        {
            var subject = $"the subject is {numOrder}";
            var body = $"This is the body of the message. Subject is {subject}" + Environment.NewLine;
            _email.SendMail(subject, toAdress, body);
        }
    }
    public class EmailSenderMock : IEmail
    {
        public bool mailSent { set; get; }
        public string subject;
        public string toAdress;
        public string body;
        public void SendMail(string to, string sender, string b)
        {
            mailSent = true;
            subject = to;
            toAdress = sender;
            body = b;
        }
    }
}
