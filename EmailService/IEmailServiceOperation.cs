using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmailService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmailServiceOperation" in both code and config file together.
    [ServiceContract (CallbackContract = typeof(INotification))]
    public interface IEmailServiceOperation
    {
        [OperationContract(IsOneWay = true)]
        void SendEmail(EmailDataContract emailData);
    }

    public interface INotification
    {
        [OperationContract(IsOneWay = true)]
        void EmailIsSent(Guid examId, bool success);
    }
}
