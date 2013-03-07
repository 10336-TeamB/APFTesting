﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ISelectedTheoryQuestion
    {
        Guid Id { get; }
        //ITheoryComponent Component { get; }
        //ITheoryQuestion Question { get; }
        string Description { get; }
        //IEnumerable<ISelectedAnswer> SelectedAnswers { get; }
        IEnumerable<IPossibleAnswer> PossibleAnswers { get; }
        int QuestionIndex { get; }
        bool IsMarkedForReview { get; }
        bool IsAnswered { get; }
    }
}
