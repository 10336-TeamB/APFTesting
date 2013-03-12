using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    public interface IFacade : IDisposable
    {
        void AnswerQuestion(Guid examId, int questionIndex, int[] selectedAnswers, bool markForReview);
        IExam CreateExam(Guid examinerId, Guid candidateId, ExamType examType);
        ITheoryComponentFormat CreateTheoryComponentFormat(ExamType examType, int numberOfQuestions, int passMark);
        IEnumerable<ICandidate> FetchCandidates(Guid examinerId);
        ISelectedTheoryQuestion FetchNextQuestion(Guid examId);
        ISelectedTheoryQuestion FetchPreviousQuestion(Guid examId);
        ISelectedTheoryQuestion FetchSpecificQuestion(Guid examId, int questionIndex);
        ISelectedTheoryQuestion ResumeTheoryExam(Guid examId);
        ITheoryComponent FetchTheoryComponentResult(Guid examId);
        IEnumerable<ISelectedTheoryQuestion> FetchTheoryComponentSummary(Guid examId);
        void SetActiveTheoryComponentFormat(Guid theoryComponentFormatId);
        void VoidExam(Guid examId);
    }
}
