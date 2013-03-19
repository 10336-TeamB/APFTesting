using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentFailed : ExamState
    {
        internal override void FetchTheoryExamResult(Action action)
        {
            action();
        }
    }
}
