using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class ExamCreated : ExamState
    {
        internal override void StartTheoryComponent(Action action)
        {
            action();
        }

        internal override void FetchFirstQuestion(Action action)
        {
            action();
        }

        internal override void FetchTheoryComponentFormat(Action action)
        {
            action();
        }

    }
}
