using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingUI.Tests
{
    internal class MockFacade : IFacade
    {
        public void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            // NO-OP
        }

        //public Guid CreateExam(Guid examinerId, Guid candidateId, ExamType examType)
        //{
        //    return Guid.NewGuid();
        //}

        public ITheoryComponentFormat CreateTheoryComponentFormat(ExamType examType, int numberOfQuestions, int passMark)
        {
            return new MockTheoryComponentFormat();
        }

        public IEnumerable<ICandidate> FetchCandidates(Guid examinerId)
        {
            yield return new MockCandidate();
        }

        public ISelectedTheoryQuestion FetchNextQuestion(Guid examId)
        {
            return new MockSelectedTheoryQuestion();
        }

        public ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId)
        {
            return new MockSelectedTheoryQuestion();
        }

        public ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex)
        {
            return new MockSelectedTheoryQuestion();
        }

        public ITheoryComponent FetchTheoryComponentResult(Guid examId)
        {
            return new MockTheoryComponent();
        }

        public IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId)
        {
            yield return new MockSelectedTheoryQuestion();
            yield return new MockSelectedTheoryQuestion();
            yield return new MockSelectedTheoryQuestion();
        }

        public void SubmitTheoryComponent(Guid examId)
        {
            // NO-OP
        }

        public void SetActiveTheoryComponentFormat(Guid theoryComponentFormatId)
        {
            // NO-OP
        }

        public void VoidExam(Guid examId)
        {
            // NO-OP
        }

        public void Dispose()
        {
            // NO-OP
        }


        public void ResetTheoryComponent()
        {
            // NO-OP
        }


        public Guid StartTheoryComponent(Guid examinerId, Guid candidateId)
        {
            return Guid.NewGuid();
        }


		public ITheoryComponentFormat FetchTheoryComponentFormat(Guid examId)
		{
			throw new NotImplementedException();
		}

		public ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId)
		{
			return new MockSelectedTheoryQuestion();
		}
	}
}
