using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace APFTestingServices
{
    public class SendEmail
    {
        public void MailEmail(string toAddress, string subject, string body, Stream stream)
        {
            string senderAddress = "teamb.email@gmail.com";
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toAddress);
            mail.From = new MailAddress(senderAddress, "APFTesting", System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //from old pdf stream
            //var stream = new PDFStream().CreatePDF();
            var attachment = new Attachment(stream, "ExamResult.pdf", "application/pdf");
            mail.Attachments.Add(attachment);

            Thread emailThread = new Thread(() => SendEmail(senderAddress, mail));
            emailThread.Start();
        }

        void SendEmail(string senderAddress, System.Net.Mail.MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(senderAddress, "tb123!@#");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            int retryTime = 0;
            const int maxRetryTime = 3;
            bool sent = false;

            while (sent)
            {
                try
                {
                    client.Send(mail);
                    sent = true;
                }
                catch (Exception)
                {
                    if (retryTime >= maxRetryTime)
                    {
                        //PANIC!
                        return;
                    }
                    ++retryTime;
                }
            }
        }
    }
}
