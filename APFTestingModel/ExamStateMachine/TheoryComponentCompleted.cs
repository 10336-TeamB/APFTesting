using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentCompleted : ExamState
    {
        internal override void FetchTheoryExamResult(Action action)
        {
            action();
        }

        internal override void AddPracticalComponentResult(Action action)
        {
            action();
        }

        internal override void SubmitPilotPracticalResults(Action action)
        {
            action();
        }

        internal override void EditPackerPracticalResult(Action action)
        {
            action();
        }

        internal override void FinaliseExam(Action action)
        {
            action();
        }

        internal override void FinalisePractical(Action action)
        {
            action();
        }
    }
}
