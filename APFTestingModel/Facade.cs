using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public class Facade : IDisposable
    {
        private ExamManager examManager = new ExamManager();

        public IExam CreateExam(Guid examinerId, Guid candidateId, ExamType examType) 
        {
            return (IExam)examManager.GenerateExam(examinerId, candidateId, examType);
        }

        private Question fetchNextQuestion(Guid examId, ref bool isLastQuestion)
        {
            return examManager.FetchNextQuestion(examId, ref isLastQuestion);
        }

        public IQuestion FetchNextQuestion(Guid examId, ref bool isLastQuestion)
        {
            return (IQuestion)fetchNextQuestion(examId, ref isLastQuestion);
        }

        private Question fetchPreviousQuestion(Guid examId, ref bool isFirstQuestion)
        {
            return examManager.FetchPreviousQuestion(examId, ref isFirstQuestion);
        }

        public IQuestion FetchPrevQuestion(Guid examId, ref bool isFirstQuestion)
        {
            return (IQuestion)fetchPreviousQuestion(examId, ref isFirstQuestion);
        }

        private Question fetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        {
            return examManager.FetchQuestion(examId, questionIndex, ref isFirstQuestion, ref isLastQuestion);
        }

        public IQuestion FetchQuestion(Guid examId, int questionIndex, ref bool isFirstQuestion, ref bool isLastQuestion)
        {
            return (IQuestion)fetchQuestion(examId, questionIndex, ref isFirstQuestion, ref isLastQuestion);
        }

        private Exam fetchExam(Guid id) {
            return examManager.FetchExam(id);
        }

        public IExam FetchExam(Guid id)
        {
            return (IExam)fetchExam(id);
        }

        public void Dispose()
        {
            // TODO: Implement Dispose method
        }
    }
}
