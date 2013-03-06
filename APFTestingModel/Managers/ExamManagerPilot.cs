using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class ExamManagerPilot : ExamManager
    {
        public ExamManagerPilot(TheoryComponentManagerPilot theoryComponentManagerPilot, PracticalComponentManagerPilot practicalComponentManagerPilot)
        {
            theoryComponentManager = theoryComponentManagerPilot;
            practicalComponentManager = practicalComponentManagerPilot;
        }

        public override Exam GenerateExam(Guid examinerId, Guid candidateId)
        {
            TheoryComponentPilot theoryComponentPilot = new TheoryComponentPilot();
            PracticalComponentPilot practicalComponentPilot = new PracticalComponentPilot();
            ExamPilot examPilot = new ExamPilot(examinerId, candidateId, theoryComponentPilot, practicalComponentPilot);
            return examPilot;
        }
    }
}
