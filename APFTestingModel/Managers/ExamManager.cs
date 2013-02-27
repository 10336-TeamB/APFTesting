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

        public Exam FetchExam(Guid examId)
        {
            return _context.Exams.FirstOrDefault(e => e.Id == examId);
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

        //public Exam GenerateExam(Guid examinerId, Guid candidateId, ExamType examType)
        //{
          
        //}

    }
}
