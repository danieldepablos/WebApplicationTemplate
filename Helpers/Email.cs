using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplication.Helpers
{
    public class Email
    {
        //private readonly SmtpClient smtpClient;

        // constants
        private const string HtmlEmailHeader = "<html><head><title></title></head><body style='font-family:arial; font-size:14px;'>";
        private const string HtmlEmailFooter = "</body></html>";

        // properties
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        // constructor
        public Email()
        {
            To = new List<string>();
            CC = new List<string>();
            BCC = new List<string>();
        }

        // send
        public void Send()
        {

            MailMessage message = new MailMessage();

            foreach (var x in To)
            {
                message.To.Add(x);
            }
            foreach (var x in CC)
            {
                message.CC.Add(x);
            }
            foreach (var x in BCC)
            {
                message.Bcc.Add(x);
            }

            try
            {

                message.Subject = Subject;
                message.Body = string.Concat(HtmlEmailHeader, Body, HtmlEmailFooter);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.From = new MailAddress(From);
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                //SmtpClient client = new SmtpClient("smtp.gmail.com");
                //SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

                string smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtpHost"];

                SmtpClient smtpClient = new SmtpClient(smtpHost, 587);

                smtpClient.Credentials = new System.Net.NetworkCredential("zelledolar@gmail.com", "D4n13l**2020");
                smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                smtpClient.Send(message);

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

    }

}