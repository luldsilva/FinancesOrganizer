using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsersAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public void SendEmail(string[] recipient, string topic, int userId, string code)
        //{
        //    Message message = new Message(recipient, topic, userId, code);
        //    var messageEmail = (MimeMessage)CreateEmailBody(message);
        //    readToSendEmail(messageEmail);
        //}

        private void readToSendEmail(MimeMessage messageEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"), 
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(messageEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Dispose();
                }
            }
        }

        //private object CreateEmailBody(Message message)
        //{
        //    var messageEmail = new MimeMessage();
        //    messageEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
        //    messageEmail.To.AddRange(message.Recipient);
        //    messageEmail.Subject = message.Topic;
        //    messageEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        //    {
        //        Text = message.Content
        //    };
        //}
    }
}