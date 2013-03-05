using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IDisposable
    {
        private APFTestingDBEntities _context = new APFTestingDBEntities();
        private ExamManager examManager = new ExamManager();

        //TODO: Implement Functionality - Pradipna
        //public IExam CreateExam(Guid examinerId, Guid candidateId, ExamType examType) 
        //{
        //    return examManager.GenerateExam(examinerId, candidateId, examType);
        //}

        //private TheoryQuestion fetchNextQuestion(Guid examId, ref bool isLastQuestion)
        //{
        //    return examManager.FetchNextQuestion(examId, ref isLastQuestion);
        //}

        //public ITheoryQuestion FetchNextQuestion(Guid examId, ref bool isLastQuestion)
        //{
        //    return fetchNextQuestion(examId, ref isLastQuestion);
        //}

        //private TheoryQuestion fetchPreviousQuestion(Guid examId, ref bool isFirstQuestion)
        //{
        //    return examManager.FetchPreviousQuestion(examId, ref isFirstQuestion);
        //}

        //public ITheoryQuestion FetchPrevQuestion(Guid examId, ref bool isFirstQuestion)
        //{
        //    return fetchPreviousQuestion(examId, ref isFirstQuestion);
        //}

        //private TheoryQuestion fetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        //{
        //    return examManager.FetchQuestion(examId, questionIndex, ref isFirstQuestion, ref isLastQuestion);
        //}

        //public ITheoryQuestion FetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        //{
        //    return fetchQuestion(examId, questionIndex, ref isFirstQuestion, ref isLastQuestion);
        //}

        //private Exam fetchExam(Guid id) {
        //    return examManager.FetchExam(id);
        //}

        //public IExam FetchExam(Guid id)
        //{
        //    return fetchExam(id);
        //}

        //Hook-in test method
        public string TestDBConnection()
        {
           return _context.TheoryQuestions.FirstOrDefault().Description;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

