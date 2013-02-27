using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IExam
    {
        Guid Id { get; }
        int ExamStatusId { get; }
        Guid TheoryComponentId { get; }
        Guid PracticalComponentId { get; }
        Guid CandidateId { get; }
        int ExamTypeId { get; }
    }
}
