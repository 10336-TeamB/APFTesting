using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ISelectedTheoryQuestion
    {
        Guid Id { get; }
        string Description { get; }
        int NumberOfCorrectAnswers { get; }
        IEnumerable<ISelectedAnswer> SelectedAnswers { get; }
        int QuestionIndex { get; }
        bool IsMarkedForReview { get; }
        bool IsAnswered { get; }
        bool IsLastQuestion { get; }
    }
}
