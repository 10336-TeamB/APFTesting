using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPilot : Exam
    {
        public ExamPilot(Guid examinerId, Guid candidateId, TheoryComponentPilot theoryComponentPilot, PracticalComponentPilot practicalComponentPilot)
            : base(examinerId, candidateId)
        {
            TheoryComponent = theoryComponentPilot;
            PracticalComponent = practicalComponentPilot;
        }
    }
}
