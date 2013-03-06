using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    class ManagerFactory
    {
        private static TheoryComponentManagerPilot createTheoryComponentManagerPilot(IEnumerable<TheoryQuestion> theoryQuestions)
        {
            return new TheoryComponentManagerPilot(theoryQuestions.OfType<TheoryQuestionPilot>());
        }

        private static TheoryComponentManagerPacker createTheoryComponentManagerPacker(IEnumerable<TheoryQuestion> theoryQuestions)
        {
            return new TheoryComponentManagerPacker(theoryQuestions.OfType<TheoryQuestionPacker>());
        }

        private static PracticalComponentManagerPilot createPracticalComponentManagerPilot()
        {
            return new PracticalComponentManagerPilot();
        }

        private static PracticalComponentManagerPacker createPracticalComponentManagerPacker()
        {
            return new PracticalComponentManagerPacker();
        }

        public static ExamManager CreateExamManager(IEnumerable<TheoryQuestion> theoryQuestions, ExamType examType)
        {
            ExamManager examManager;

            if (examType == ExamType.PackerExam)
            {
                examManager = new ExamManagerPacker(createTheoryComponentManagerPacker(theoryQuestions), createPracticalComponentManagerPacker());
            }
            else
            {
                examManager = new ExamManagerPilot(createTheoryComponentManagerPilot(theoryQuestions), createPracticalComponentManagerPilot());
            }

            return examManager;
        }
    }
}
