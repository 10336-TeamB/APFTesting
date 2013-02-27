using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IQuestion
    {
        Guid Id { get; }
        int NumberOfCorrectAnswer { get; }
        bool IsActive { get; }
        int ExamTypeId { get; }
        string Description { get; }
        IEnumerable<IPossibleAnswer> PossibleAnswers { get; }
        int QuestionNumber { get; }
    }
}
