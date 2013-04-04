using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ICandidate
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        IExam LatestExam { get; }

        ExamStatusEnum LatestExamStatus { get; } //REFACTORED

    }
}
