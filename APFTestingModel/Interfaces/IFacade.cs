using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IFacade : IDisposable
    {
        void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview);
		Guid StartTheoryComponent(Guid examinerId, Guid candidateId);
        //ITheoryComponentFormat CreateTheoryComponentFormat(ExamType examType, int numberOfQuestions, int passMark);
        
		IEnumerable<ICandidate> FetchCandidates(Guid examinerId);
        ISelectedTheoryQuestion FetchFirstQuestion(Guid examId);
        ISelectedTheoryQuestion FetchNextQuestion(Guid examId);
        ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId);

        ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex);
		ITheoryComponentFormat FetchTheoryComponentFormatForExam(Guid examId);
		ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId);
        ITheoryComponent FetchTheoryComponentResult(Guid examId);

        //Guid StartExam(Guid examinerId, Guid candidateId);
        //ISelectedTheoryQuestion ResumeTheoryExam(Guid examId);

        Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy);
        Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy);
		
        IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId);
        void SubmitTheoryComponent(Guid examId);

        IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid candidateId);
        IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId, out bool isCompetent);
        IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId);

        void SetActiveTheoryComponentFormat(Guid theoryComponentFormatId);
        void VoidExam(Guid examId);
        void ResetTheoryComponent(Guid examId);

        void SubmitPilotPracticalResults(Guid examId, List<PilotPracticalResult> results);
        void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result);
        void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result);

        void FinalisePractical(Guid examId);

        ICandidatePacker FetchPacker(Guid candidateId);
        ICandidatePilot FetchPilot(Guid candidateId);
        void EditPilot(Guid candidateId, CandidatePilotDetails details);
        void EditPacker(Guid candidateId, CandidatePackerDetails details);

        IAssessmentTaskPilot CreateAssessmentTaskPilot(AssessmentTaskPilotDetails details);
        IAssessmentTaskPilot EditAssessmentTaskPilot(Guid id, AssessmentTaskPilotDetails details);
        void DeleteAssessmentTaskPilot(Guid id);
        IEnumerable<IAssessmentTaskPilot> FetchAllAssessmentTaskPilot();
        IAssessmentTaskPilot FetchAssessmentTaskPilot(Guid AssessmentTaskId);

        IEnumerable<ITheoryQuestion> FetchAllTheoryQuestionsPilot();

        IEnumerable<IPracticalComponentTemplatePilot> FetchAllPracticalComponentTemplatePilots();
        IEnumerable<IPracticalComponentTemplatePacker> FetchAllPracticalComponentTemplatePackers();

        void CreateExaminer(ExaminerDetails examinerDetails);
        void EditExaminer(Guid examinerId, ExaminerDetails examinerDetails);
        void DeleteExaminer(Guid examinerId);
        void EditExaminerActiveStatus(Guid examinerId, bool isActive);

        ITheoryComponentFormat[][] FetchAllTheoryExamFormats();
        ITheoryComponentFormat FetchTheoryExamFormatById(Guid formatId);
        void CreateTheoryExamFormat(ExamType examType, int numberOfQuestions, int passMark, int timeLimit);
        void EditTheoryExamFormat(Guid formatId, int numberOfQuestions, int passMark, int timeLimit);
        void DeleteTheoryExamFormat(Guid formatId);

        IPracticalComponentTemplatePilot FetchPracticalTemplatePilotById(Guid templateId);
        Guid CreatePracticalComponentTemplatePilot(IEnumerable<Guid> tasks);
        Guid EditPracticalComponentTemplatePilot(Guid templateId, IEnumerable<Guid> taskIds);

        IPracticalComponentTemplatePacker FetchPracticalTemplatePackerById(Guid templateId);
        void CreatePracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks);
        void EditPracticalComponentTemplatePacker(Guid templateId, int numOfRequiredAssessmentTasks);
        void DeletePracticalTemplatePacker(Guid templateId);
        void SetActivePracticalTemplatePacker(Guid templateId);

		void CreateTheoryQuestion(TheoryQuestionDetails questionDetails, ExamType examType);

        IEnumerable<IExaminer> FetchAllExaminers();
        IExaminer FetchExaminer(Guid examinerId);


        ITheoryQuestion FetchTheoryQuestion(Guid questionId);
        void EditTheoryQuestion(TheoryQuestionDetails questionDetails, Guid questionId);

        bool Login(string username, string password, bool rememberMe);
        void Logout();

        void DeleteTheoryQuestion(Guid questionId);

        void ToggleTheoryQuestionActivation(Guid questionId);

        void FinaliseExam(Guid examId, ExamType examType);
    }
}
