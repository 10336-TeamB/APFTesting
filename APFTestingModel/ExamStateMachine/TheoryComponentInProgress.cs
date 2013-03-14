using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentInProgress : ExamState
    {
        internal override void FetchNextQuestion(Action action)
        {
            action();
        }

        internal override void FetchPreviousQuestion(Action action)
        {
            action();
        }

        internal override void FetchSpecificQuestion(Action action)
        {
            action();
        }

        internal override void AnswerQuestion(Action action)
        {
            action();
        }
    }
}
