using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmailService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailServiceOperation" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmailServiceOperation.svc or EmailServiceOperation.svc.cs at the Solution Explorer and start debugging.
    public class EmailServiceOperation : IEmailServiceOperation
    {
        void IEmailServiceOperation.SendEmail(EmailDataContract emailData)
        {
            PDFGenerator pdfGenerator = new PDFGenerator();

            MemoryStream pdfStream = pdfGenerator.CreatePDF(emailData.Exam, emailData.ExamType);

            string senderAddress = "teamb.email@gmail.com";
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(emailData.ToAddress);
            mail.From = new MailAddress(senderAddress, "APFTesting", System.Text.Encoding.UTF8);
            mail.Subject = emailData.Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = emailData.Body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //from old pdf stream
            //var stream = new PDFStream().CreatePDF();
            var attachment = new Attachment(pdfStream, "ExamResult.pdf", "application/pdf");
            mail.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(senderAddress, "tb123!@#");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            client.Send(mail);
        }
    }
}
