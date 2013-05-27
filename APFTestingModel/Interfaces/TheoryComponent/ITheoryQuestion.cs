using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ITheoryQuestion
    {
        Guid Id { get; }
        int NumberOfCorrectAnswers { get; }
        bool IsActive { get; }
		string ImagePath { get; }
		string Description { get; }
		TheoryQuestionCategory Category { get; }
		IEnumerable<IAnswer> Answers { get; }
        bool EditableOrDeletable { get; }
    }
}
