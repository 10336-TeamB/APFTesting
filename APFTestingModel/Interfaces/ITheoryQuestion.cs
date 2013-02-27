using System;
using System.Collections.Generic;

namespace APFTestingModel.Interfaces
{
    public interface ITheoryQuestion
    {
        Guid Id { get; }
        string Description { get; }
        IEnumerable<IPossibleAnswer> PossibleAnswers { get; }
        int NumberOfCorrectAnswer { get; }
        int QuestionNumber { get; }
    }
}
