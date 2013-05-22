using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class PracticalComponentCompleted : ExamState
    {
        internal override void FinaliseExam(Action action)
        {
            action();
        }

        internal override void FetchTheoryExamResult(Action action)
        {
            action();
        }

        internal override void FetchPracticalExamResult(Action action)
        {
            action();
        }
    }
}
