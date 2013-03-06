using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IAssessmentTaskPacker
    {
        Guid Id { get; }
        DateTime Date { get; }
        string CanopyType { get; }
        string CanopyTypeSerialNumber { get; }
        string SupervisorId { get; }
        string HarnessContainerType { get; }
        string HarnessContainerSerialNumber { get; }
        string Note { get; }
    }
}
