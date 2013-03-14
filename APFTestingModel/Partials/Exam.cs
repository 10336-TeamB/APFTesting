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
        protected ExamState examState;

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
                OnStatusChanged();
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
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchNextQuestion(); };
            examState.FetchNextQuestion(a);
            return question;
        }

        public SelectedTheoryQuestion FetchPreviousQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchPreviousQuestion(); };
            examState.FetchPreviousQuestion(a);
            return question;
        }

        public SelectedTheoryQuestion FetchSpecificQuestion(int index)
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchSpecificQuestion(index); };
            examState.FetchSpecificQuestion(a);
            return question;
        }

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            Action a = delegate { TheoryComponent.AnswerQuestion(questionIndex, selectedAnswers, markForReview); };
            examState.AnswerQuestion(a);
        }

        public void OnStatusChanged()
        {
            switch (ExamStatusId)
            {
                case (int)ExamStatus.ExamCompleted:
                    examState = new ExamCompleted();
                    break;
                case (int)ExamStatus.ExamCreated:
                    examState = new ExamCreated();
                    break;
                case (int)ExamStatus.ExamVoided:
                    examState = new ExamVoided();
                    break;
                case (int)ExamStatus.NoExamCreated:
                    examState = new NoExamCreated();
                    break;
                case (int)ExamStatus.PracticalComponentCompleted:
                    examState = new PracticalComponentCompleted();
                    break;
                case (int)ExamStatus.PracticalComponentFailed:
                    examState = new PracticalComponentFailed();
                    break;
                case (int)ExamStatus.TheoryComponentCompleted:
                    examState = new TheoryComponentCompleted();
                    break;
                case (int)ExamStatus.TheoryComponentFailed:
                    examState = new TheoryComponentFailed();
                    break;
                case (int)ExamStatus.TheoryComponentInProgress:
                    examState = new TheoryComponentInProgress();
                    break;
            }
        }
    }
}
