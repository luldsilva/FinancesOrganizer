using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> Recipient { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> recipient, string topic, int userId, string code)
        {
            Recipient = new List<MailboxAddress>();
            Recipient.AddRange(recipient.Select(d => new MailboxAddress("Lucas teste", d)));
            Topic = topic;
            Content = $"https://localhost:44365/active?UserId={userId}&CodeActivation={code}";
        }
    }
}
