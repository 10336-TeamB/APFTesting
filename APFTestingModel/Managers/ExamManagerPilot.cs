using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class ExamManagerPilot : ExamManager
    {
        public ExamManagerPilot(TheoryComponentManagerPilot theoryComponentManagerPilot)
        {
            theoryComponentManager = theoryComponentManagerPilot;
        }

        public ExamManagerPilot(PracticalComponentManagerPilot practicalComponentManagerPilot)
        {
            practicalComponentManager = practicalComponentManagerPilot;
        }

        public ExamManagerPilot(TheoryComponentManagerPilot theoryComponentManagerPilot, PracticalComponentManagerPilot practicalComponentManagerPilot)
        {
            theoryComponentManager = theoryComponentManagerPilot;
            practicalComponentManager = practicalComponentManagerPilot;
        }

        public override Exam GenerateExam(Guid examinerId, Guid candidateId)
        {
            TheoryComponentPilot theoryComponentPilot = (TheoryComponentPilot)theoryComponentManager.GenerateTheoryComponent();
            PracticalComponentPilot practicalComponentPilot = (PracticalComponentPilot)practicalComponentManager.GeneratePracticalComponent();

            ExamPilot examPilot = new ExamPilot(examinerId, candidateId, theoryComponentPilot, practicalComponentPilot);
            return examPilot;
        }

        public AssessmentTask CreateAssessmentTask(AssessmentTaskPilotDetails details)
        {
            return (practicalComponentManager as PracticalComponentManagerPilot).CreateAssessmentTask(details);
        }

        public PracticalComponentTemplate CreatePracticalComponentTemplatePilot(List<AssessmentTaskPilot> tasks)
        {
            return (practicalComponentManager as PracticalComponentManagerPilot).CreatePracticalComponentTemplatePilot(tasks);
        }
    }
}
