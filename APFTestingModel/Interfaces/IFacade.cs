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
		ITheoryComponentFormat FetchTheoryComponentFormat(Guid examId);
		ISelectedTheoryQuestion ResumeTheoryComponent(Guid examId);
        ITheoryComponent FetchTheoryComponentResult(Guid examId);

        //Guid StartExam(Guid examinerId, Guid candidateId);
        //ISelectedTheoryQuestion ResumeTheoryExam(Guid examId);

        Guid CreateCandidate(CandidatePilotDetails details, Guid createdBy);
        Guid CreateCandidate(CandidatePackerDetails details, Guid createdBy);
		
        IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId);
        void SubmitTheoryComponent(Guid examId);

        IEnumerable<ISelectedAssessmentTask> FetchAssessmentTasksPilot(Guid candidateId);
        IEnumerable<IAssessmentTaskPacker> FetchAssessmentTasksPacker(Guid examId);
        IAssessmentTaskPacker FetchSingleAssessmentTaskPacker(Guid examId, Guid taskId);

        void SetActiveTheoryComponentFormat(Guid theoryComponentFormatId);
        void VoidExam(Guid examId);
        void ResetTheoryComponent();

        void SubmitPilotPracticalResults(Guid examId, List<PilotPracticalResult> results);
        void SubmitPackerPracticalResult(Guid examId, PackerPracticalResult result);
        void EditPackerPracticalResult(Guid examId, Guid taskId, PackerPracticalResult result);

        void FinalisePractical(Guid examId);

        ICandidatePacker FetchPacker(Guid candidateId);
        ICandidatePilot FetchPilot(Guid candidateId);
    }
}
