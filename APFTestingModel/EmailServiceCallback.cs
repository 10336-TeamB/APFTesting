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
            facade.Dispose();
        }

        public void CallEmailService(EmailServiceReference.EmailDataContract emailData)
        {
            InstanceContext context = new InstanceContext(this);
            proxy = new EmailServiceReference.EmailServiceOperationClient(context);
            proxy.SendEmailAsync(emailData);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
                proxy.Close();
            }
            // get rid of unmanaged resources
        }

        ~EmailServiceCallback()
        {
            Dispose(true);
        }
    }
}
