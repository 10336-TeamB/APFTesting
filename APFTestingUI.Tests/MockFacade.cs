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

		public void ResetTheoryComponent(Guid examId)
		{
			// NO-OP
		}

		public Guid StartTheoryComponent(Guid examinerId, Guid candidateId)
		{
			return Guid.NewGuid();
		}

		public ITheoryComponentFormat FetchTheoryComponentFormatForExam(Guid examId)
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


		public void EditPilot(Guid candidateId, CandidatePilotDetails details)
		{
			throw new NotImplementedException();
		}

		public void EditPacker(Guid candidateId, CandidatePackerDetails details)
		{
			throw new NotImplementedException();
		}


		public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId, out bool isCompetent)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId)
		{
			throw new NotImplementedException();
		}


		public IAssessmentTaskPilot CreateAssessmentTaskPilot(AssessmentTaskPilotDetails details)
		{
			throw new NotImplementedException();
		}

		public IAssessmentTaskPilot EditAssessmentTaskPilot(Guid id, AssessmentTaskPilotDetails details)
		{
			throw new NotImplementedException();
		}

		public void DeleteAssessmentTaskPilot(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IAssessmentTaskPilot> FetchAllAssessmentTaskPilot()
		{
			throw new NotImplementedException();
		}


		public IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot()
		{
			throw new NotImplementedException();
		}


		public IAssessmentTaskPilot FetchAssessmentTaskPilot(Guid AssessmentTaskId)
		{
			throw new NotImplementedException();
		}


		public ITheoryComponentFormat[][] FetchAllTheoryExamFormats()
		{
			throw new NotImplementedException();
		}

		public void CreateTheoryExamFormat(ExamType examType, int numberOfQuestions, int passMark, int timeLimit)
		{
			throw new NotImplementedException();
		}

		public void EditTheoryExamFormat(Guid formatId, int numberOfQuestions, int passMark, int timeLimit)
		{
			throw new NotImplementedException();
		}

		public void DeleteTheoryExamFormat(Guid formatId)
		{
			throw new NotImplementedException();
		}


		public void CreateExaminer(ExaminerDetails examinerDetails)
		{
			throw new NotImplementedException();
		}

		public void EditExaminer(Guid examinerId, ExaminerDetails examinerDetails)
		{
			throw new NotImplementedException();
		}

		public void DeleteExaminer(Guid examinerId)
		{
			throw new NotImplementedException();
		}
		public void EditExaminerActiveStatus(Guid examinerId, bool isActive)
		{
			throw new NotImplementedException();
		}

		public ITheoryComponentFormat FetchTheoryExamFormatById(Guid formatId)
		{
			throw new NotImplementedException();
		}

		public void CreateTheoryQuestion(TheoryQuestionDetails questionDetails, ExamType examType)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IExaminer> FetchAllExaminers()
		{
			throw new NotImplementedException();
		}

		public IExaminer FetchExaminer(Guid examinerId)
		{
			throw new NotImplementedException();
		}

        public IEnumerable<IPracticalComponentTemplatePilot> FetchAllPracticalComponentTemplatePilots()
		{
            throw new NotImplementedException();
        }
		
        public ITheoryQuestion FetchTheoryQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPracticalComponentTemplatePacker> FetchAllPracticalComponentTemplatePackers()
        {
            throw new NotImplementedException();
        }

        public void CreatePracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks)
		{
            throw new NotImplementedException();
        }
		
        public void EditTheoryQuestion(TheoryQuestionDetails questionDetails, Guid questionId)

        {
            throw new NotImplementedException();
        }


        public bool Login(string username, string password, bool rememberMe)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }


        public IPracticalComponentTemplatePacker FetchPracticalTemplatePackerById(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public void EditPracticalComponentTemplatePacker(Guid templateId, int numOfRequiredAssessmentTasks)
        {
            throw new NotImplementedException();
        }


        public void DeletePracticalTemplatePacker(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public void SetActivePracticalTemplatePacker(Guid templateId)
        {
            throw new NotImplementedException();
        }

        public Guid CreatePracticalComponentTemplatePilot(IEnumerable<Guid> tasks)
        {
            throw new NotImplementedException();
        }


        public IPracticalComponentTemplatePilot FetchPracticalTemplatePilotById(Guid templateId)
		{
            throw new NotImplementedException();
        }

        public void DeleteTheoryQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }


        public Guid EditPracticalComponentTemplatePilot(Guid templateId, IEnumerable<Guid> taskIds)
		{
            throw new NotImplementedException();
        }
		
        public void ToggleTheoryQuestionActivation(Guid questionId)
        {
            throw new NotImplementedException();
        }
    }
}