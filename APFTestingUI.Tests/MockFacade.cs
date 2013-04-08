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
			return new MockTheoryComponentFormat();
		}

		public ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId)
		{
			return new MockSelectedTheoryQuestion();
		}

        public ISelectedTheoryQuestion FetchFirstQuestion(Guid examId)
        {
            return new MockSelectedTheoryQuestion();
        }

        public IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid candidateId)
        {
            throw new NotImplementedException();
        }

        public void SubmitPilotPracticalResults(Guid examId, List<PilotPracticalResult> results)
        {
            throw new NotImplementedException();
        }

        public Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy)
        {
            throw new NotImplementedException();
        }

        public Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy)
        {
            throw new NotImplementedException();
        }

        public void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId)
        {
            throw new NotImplementedException();
        }

        public void FinalisePractical(Guid examId)
        {
            throw new NotImplementedException();
        }

        public IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId)
        {
            throw new NotImplementedException();
        }

        public void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result)
        {
            throw new NotImplementedException();
        }


        public ICandidatePacker FetchPacker(Guid candidateId)
        {
            throw new NotImplementedException();
        }

        public ICandidatePilot FetchPilot(Guid candidateId)
        {
            throw new NotImplementedException();
        }
    }
}
