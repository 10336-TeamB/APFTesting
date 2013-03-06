using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPilot : IExamPilot
    {
        public ExamPilot(Guid examinerId, Guid candidateId, TheoryComponentPilot theoryComponentPilot, PracticalComponentPilot practicalComponentPilot)
            : base(examinerId, candidateId)
        {
            TheoryComponent = theoryComponentPilot;
            base.PracticalComponent = practicalComponentPilot;
        }

        public new IPracticalComponentPilot PracticalComponent
        {
            get { return base.PracticalComponent as PracticalComponentPilot; }
        }
    }
}
