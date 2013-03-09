using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    public enum ExamStatus
    {
        ExamCreated = 1,
        TheoryComponentInProgress = 2,
        TheoryComponentFailed = 3,
        TheoryComponentCompleted = 4,
        PracticalComponentFailed = 5,
        PracticalComponentCompleted = 6,
        ExamCompleted = 7,
        ExamVoided = 8,
        Count = 8
    }

    internal abstract partial class Exam : IExam
    {
        #region Constructors

        public Exam() { }

        public Exam(Guid examinerId, Guid candidateId)
        {
            CandidateId = candidateId;
            ExaminerId = examinerId;
            ExamStatusId = 1;
        }

        #endregion

        public ExamStatus ExamStatus
        {
            get
            {
                if (ExamStatusId > (int)ExamStatus.Count || ExamStatusId < 0)
                {
                    throw new BusinessRuleExcpetion("Exam Status invalid");
                }
                return (ExamStatus)ExamStatusId;
            }
        }

        public IEnumerable<SelectedTheoryQuestion> SelectedTheoryQuestions
        {
            get
            {
                return TheoryComponent.SelectedTheoryQuestions;
            }
        }

        // Commented out to allow compilation

        public SelectedTheoryQuestion FetchNextQuestion()
        {
            return TheoryComponent.FetchNextQuestion();
        }

        public SelectedTheoryQuestion FetchPreviousQuestion()
        {
            return TheoryComponent.FetchPreviousQuestion();
        }

        public SelectedTheoryQuestion FetchSpecificQuestion(int index)
        {
            return TheoryComponent.FetchSpecificQuestion(index);
        }

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            TheoryComponent.AnswerQuestion(questionIndex, selectedAnswers, markForReview);
        }
    }
}
