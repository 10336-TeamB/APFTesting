using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IExamPilot
    {
        Guid Id { get; }
        Guid? CandidateId { get; }
        ExamStatus ExamStatus { get; }
        IPracticalComponentPilot PracticalComponent { get; }

        // TODO: Adam - implement these interfaces
        // ICandidate Candidate { get; } 
        // IExaminer Examiner { get; }
        // ITheoryComponent TheoryComponent { get; }
    }
}
