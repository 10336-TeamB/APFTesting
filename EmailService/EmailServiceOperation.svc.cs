﻿using System;
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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EmailServiceOperation : IEmailServiceOperation
    {
        void IEmailServiceOperation.SendEmail(EmailDataContract emailData)
        {
            PDFGenerator pdfGenerator = new PDFGenerator();

            MemoryStream pdfStream = pdfGenerator.CreatePDF(emailData.Exam, emailData.ExaminerNumber, emailData.ExamType, emailData.RequiredPackerPacks);
            bool success = false;
            
            if (pdfStream != null)
            {
                string senderAddress = "teamb.email@gmail.com";
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add("teamb@live.com.au");
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

                
                int retry = 0;
                const int maxRetry = 3;

                while (!success && retry < maxRetry)
                {
                    try
                    {
                        client.Send(mail);
                        success = true;
                    }
                    catch (Exception)
                    {
                        ++retry;
                    }
                }
            }

            INotification notification = OperationContext.Current.GetCallbackChannel<INotification>();
            notification.EmailIsSent(emailData.ExamId, success);
        }
    }
}
