using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    class EmailServiceCallback : EmailServiceReference.IEmailServiceOperationCallback, IDisposable
    {
        private EmailServiceReference.EmailServiceOperationClient proxy;

        public void EmailIsSent(Guid examId, bool success)
        {
            Facade facade = new Facade();
            facade.FinaliseExamUpdateStatus(examId, success);
        }

        public void CallEmailService(EmailServiceReference.EmailDataContract emailData)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new EmailServiceReference.EmailServiceOperationClient(context);
            proxy.SendEmailAsync(emailData);
        }

        public void Dispose()
        {
            proxy.Close();
        }
    }
}
