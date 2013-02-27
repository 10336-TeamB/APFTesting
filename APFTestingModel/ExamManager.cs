using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public enum ExamType
    {
        PACKER_EXAM = 2, PILOT_EXAM = 1
    }

    internal class ExamManager : Manager
    {
        private PracticalComponentManager practicalComponentManager = new PracticalComponentManager();
        private TheoryComponentManager theoryComponentManager = new TheoryComponentManager();

        private TheoryComponentFormat TheoryComponentPackerFormat
        {
            get
            {
                return context.TheoryComponentFormats.FirstOrDefault(f => f.IsActive && f.ExamTypeId == (int)ExamType.PACKER_EXAM);
            }
        }

        private TheoryComponentFormat TheoryComponentPilotFormat
        {
            get
            {
                return context.TheoryComponentFormats.FirstOrDefault(f => f.IsActive && f.ExamTypeId == (int)ExamType.PILOT_EXAM);
            }
        }

        private PracticalComponentTemplate PracticalComponentPilotTemplate
        {
            get
            {
                return context.PracticalComponentTemplates.FirstOrDefault(t => t.ExamTypeId == (int)ExamType.PILOT_EXAM);
            }
        }

        private PracticalComponentTemplate PracticalComponentPackerTemplate
        {
            get
            {
                return context.PracticalComponentTemplates.FirstOrDefault(t => t.ExamTypeId == (int)ExamType.PACKER_EXAM);
            }
        }

        public Exam FetchExam(Guid examId)
        {
            return context.Exams.FirstOrDefault(e => e.Id == examId);
        }

        public Question FetchNextQuestion(Guid examId, ref bool isLastQuestion)
        {
            Exam exam = FetchExam(examId);
            return exam.FetchNextQuestion(ref isLastQuestion);
        }

        public Question FetchPreviousQuestion(Guid examId, ref bool isLastQuestion)
        {
            Exam exam = FetchExam(examId);
            return exam.FetchPreviousQuestion(ref isLastQuestion);
        }

        public Question FetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        {
            Exam exam = FetchExam(examId);
            return exam.FetchQuestion(questionIndex, ref isFirstQuestion, ref isLastQuestion);
        }

        public Exam GenerateExam(Guid examinerId, Guid candidateId, ExamType examType)
        {
            TheoryComponentFormat theoryExamFormat = (examType == ExamType.PILOT_EXAM) ? TheoryComponentPilotFormat : TheoryComponentPackerFormat;
            PracticalComponentTemplate practicalExamTemplate = (examType == ExamType.PILOT_EXAM) ? PracticalComponentPilotTemplate : PracticalComponentPackerTemplate;

            Exam exam = new Exam(examinerId, candidateId, theoryExamFormat.Id, practicalExamTemplate.Id, examType);

            theoryComponentManager.selectRandomQuestion(exam, examType);

            return exam;
        }

    }
}
