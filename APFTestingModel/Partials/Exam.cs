using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    public enum ExamStatus
    {
        NoExamCreated = 0,
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
                    throw new BusinessRuleExcpetion("Exam Status is invalid");
                }
                return (ExamStatus)ExamStatusId;
            }
            set
            {
                ExamStatusId = (int)value;
            }
        }

        public bool TheoryComponentCompetency
        {
            get
            {
                return TheoryComponent.IsCompetent;
            }
        }

        public IEnumerable<SelectedTheoryQuestion> SelectedTheoryQuestions
        {
            get
            {
                return TheoryComponent.SelectedTheoryQuestions;
            }
        }

        //This method is just gonna throw an exception if the theory component is not in progress so that 
        //no one is able to modify the answers after or before a theory exam
        private void checkTheoryComponentStatus() {
            if (ExamStatusId != (int)ExamStatus.TheoryComponentInProgress)
            {
                throw new BusinessRuleExcpetion("Theory Component is not in progress");
            }
        }

        public SelectedTheoryQuestion FetchNextQuestion()
        {
            checkTheoryComponentStatus();
            return TheoryComponent.FetchNextQuestion();
        }

        public SelectedTheoryQuestion FetchPreviousQuestion()
        {
            checkTheoryComponentStatus();
            return TheoryComponent.FetchPreviousQuestion();
        }

        public SelectedTheoryQuestion FetchSpecificQuestion(int index)
        {
            checkTheoryComponentStatus();
            return TheoryComponent.FetchSpecificQuestion(index);
        }

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            checkTheoryComponentStatus();
            TheoryComponent.AnswerQuestion(questionIndex, selectedAnswers, markForReview);
        }
    }
}
