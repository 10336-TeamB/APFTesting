using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentInProgress : ExamState
    {
        internal override void FetchFirstQuestion(Action action)
        {
            action();
        }
        
        internal override void FetchNextQuestion(Action action)
        {
            action();
        }

        internal override void FetchPreviousQuestion(Action action)
        {
            action();
        }

        internal override void FetchCurrentQuestion(Action action)
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

        internal override void VoidExam(Action action)
        {
            action();
        }

        internal override void SubmitTheoryComponent(Action action)
        {
            action();
        }

        internal override void StartTheoryComponent(Action action)
        {
            action();
        }
    }
}
