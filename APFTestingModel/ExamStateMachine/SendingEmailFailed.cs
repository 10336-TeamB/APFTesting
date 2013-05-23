using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class SendingEmailFailed : ExamState
    {
        internal override void FinaliseExam(Action action)
        {
            action();
        }
    }
}
