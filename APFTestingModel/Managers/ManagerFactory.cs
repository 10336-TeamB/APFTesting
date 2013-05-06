using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    class ManagerFactory
    {
        private static TheoryComponentManagerPilot createTheoryComponentManagerPilot(IEnumerable<TheoryQuestion> theoryQuestions, TheoryComponentFormat activeTheoryFormat)
        {
            return new TheoryComponentManagerPilot(theoryQuestions.OfType<TheoryQuestionPilot>(), activeTheoryFormat);
        }

        private static TheoryComponentManagerPacker createTheoryComponentManagerPacker(IEnumerable<TheoryQuestion> theoryQuestions, TheoryComponentFormat activeTheoryFormat)
        {
            return new TheoryComponentManagerPacker(theoryQuestions.OfType<TheoryQuestionPacker>(), activeTheoryFormat);
        }

        private static PracticalComponentManagerPilot createPracticalComponentManagerPilot(PracticalComponentTemplate activePracticalTemplate)
        {
            return new PracticalComponentManagerPilot(activePracticalTemplate);
        }

        private static PracticalComponentManagerPacker createPracticalComponentManagerPacker(PracticalComponentTemplate activePracticalTemplate)
        {
            return new PracticalComponentManagerPacker(activePracticalTemplate);
        }

        public static ExamManager CreateExamManager(IEnumerable<TheoryQuestion> theoryQuestions, TheoryComponentFormat activeTheoryFormat, PracticalComponentTemplate activePracticalTemplate, ExamType examType)
        {
            ExamManager examManager;

            switch (examType)
            {
                case ExamType.PilotExam:
                    examManager = new ExamManagerPilot(createTheoryComponentManagerPilot(theoryQuestions, activeTheoryFormat), createPracticalComponentManagerPilot(activePracticalTemplate));
                    break;
                case ExamType.PackerExam:
                    examManager = new ExamManagerPacker(createTheoryComponentManagerPacker(theoryQuestions, activeTheoryFormat), createPracticalComponentManagerPacker(activePracticalTemplate));
                    break;
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }

            return examManager;
        }

        // Creates a theory exam manager with no associated data (i.e. existing formats or templates)
        public static ExamManager CreateTheoryExamManager(ExamType examType)
        {
            switch (examType)
            {
                case ExamType.PilotExam:
                    return new ExamManagerPilot(new TheoryComponentManagerPilot());
                case ExamType.PackerExam:
                    return new ExamManagerPacker(new TheoryComponentManagerPacker());
                default:
                    throw new BusinessRuleException("Invalid exam type provided");
            }
        }
    }
}
