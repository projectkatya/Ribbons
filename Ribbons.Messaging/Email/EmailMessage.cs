using MimeKit;
using System.Collections.Generic;

namespace Ribbons.Messaging.Email
{
    public sealed class EmailMessage
    {
        private MimeMessage Message { get; }
        private Multipart Content { get; }
        private BodyBuilder BodyBuilder { get; }
        private List<MimePart> Attachments { get; }

        public EmailMessage()
        {
            Message = new();
            Content = new();
            BodyBuilder = new();
            Attachments = new();
        }

        public EmailMessage SetSender(string name, string address)
        {
            Message.Sender = new MailboxAddress(name, address);
            return this;
        }

        public EmailMessage SetSubject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        public EmailMessage SetPlainTextBody(string content)
        {
            BodyBuilder.TextBody = content;
            return this;
        }

        public EmailMessage SetHtmlBody(string content)
        {
            BodyBuilder.HtmlBody = content;
            return this;
        }

        public EmailMessage AddRecipient(string name, string address)
        {
            Message.To.Add(new MailboxAddress(name, address));
            return this;
        }

        public EmailMessage AddCc(string name, string address)
        {
            Message.Cc.Add(new MailboxAddress(name, address));
            return this;
        }

        public EmailMessage AddBcc(string name, string address)
        {
            Message.Bcc.Add(new MailboxAddress(name, address));
            return this;
        }

        public EmailMessage AddAttachment(string fileName, byte[] attachment)
        {
            return this;
        }

        internal MimeMessage Build()
        {
            Content.Add(BodyBuilder.ToMessageBody());
            
            foreach (MimePart attachment in Attachments)
            {
                Content.Add(attachment);
            }

            Message.Body = Content;
            
            return Message;
        }
    }
}