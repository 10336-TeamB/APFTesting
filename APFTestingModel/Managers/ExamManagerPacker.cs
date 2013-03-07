using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class ExamManagerPacker : ExamManager
    {
        public ExamManagerPacker(TheoryComponentManagerPacker theoryComponentManagerPacker, PracticalComponentManagerPacker practicalComponentManagerPacker)
        {
            theoryComponentManager = theoryComponentManagerPacker;
            practicalComponentManager = practicalComponentManagerPacker;
        }

        public override Exam GenerateExam(Guid examinerId, Guid candidateId)
        {
            TheoryComponentPacker theoryComponentPacker = (TheoryComponentPacker)theoryComponentManager.GenerateTheoryComponent();
            PracticalComponentPacker practicalComponentPacker = (PracticalComponentPacker)practicalComponentManager.GeneratePracticalComponent();

            ExamPacker examPacker = new ExamPacker(examinerId, candidateId, theoryComponentPacker, practicalComponentPacker);
            return examPacker;
        }
    }
}
