using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public enum ExamType
    {
        PilotExam = 1, PackerExam = 2
    }

    internal class ExamManager : Manager
    {
        private PracticalComponentManager practicalComponentManager = new PracticalComponentManager();
        private TheoryComponentManager theoryComponentManager = new TheoryComponentManager();

        // Commented out to allow compilation
        //public Exam FetchExam(Guid examId)
        //{
        //    return _context.Exams.FirstOrDefault(e => e.Id == examId);
        //}

        //public TheoryQuestion FetchNextQuestion(Guid examId, ref bool isLastQuestion)
        //{
        //    Exam exam = FetchExam(examId);
        //    return exam.FetchNextQuestion(ref isLastQuestion);
        //}

        //public TheoryQuestion FetchPreviousQuestion(Guid examId, ref bool isLastQuestion)
        //{
        //    Exam exam = FetchExam(examId);
        //    return exam.FetchPreviousQuestion(ref isLastQuestion);
        //}

        //public TheoryQuestion FetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        //{
        //    Exam exam = FetchExam(examId);
        //    return exam.FetchQuestion(questionIndex, ref isFirstQuestion, ref isLastQuestion);
        //}

        //TODO: Create GenerateExam Method
        //public Exam GenerateExam(Guid examinerId, Guid candidateId, ExamType examType)
        //{
          
        //}

    }
}
