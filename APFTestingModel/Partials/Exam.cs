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
        protected ExamState _examState;

        #region Constructors

        public Exam() { }

        public Exam(Guid examinerId, Guid candidateId)
        {
            CandidateId = candidateId;
            ExaminerId = examinerId;
            ExamStatusId = 1;
        }

        #endregion

        #region Properties

        public int CurrentTheoryQuestionIndex
        {
            get
            {
                return TheoryComponent.CurrentQuestionIndex;
            }
        }

        public ExamStatus ExamStatus
        {
            get
            {
                if (ExamStatusId > (int)ExamStatus.Count || ExamStatusId < 0)
                {
                    throw new BusinessRuleException("Exam Status is invalid");
                }
                return (ExamStatus)ExamStatusId;
            }
            private set
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

        #endregion

        #region Methods

        public TheoryComponentFormat FetchTheoryComponentFormat()
		{
            TheoryComponentFormat format = null;
            Action a = delegate { format = TheoryComponent.TheoryComponentFormat; };
            _examState.FetchTheoryComponentFormat(a);

            return format;
		}
        
        public SelectedTheoryQuestion FetchFirstQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate
            {
                question = TheoryComponent.FetchFirstQuestion();
                ExamStatus = ExamStatus.TheoryComponentInProgress;
            };
            _examState.FetchFirstQuestion(a);
            return question;
        }

        public SelectedTheoryQuestion FetchNextQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchNextQuestion(); };
            _examState.FetchNextQuestion(a);
            
            return question;
        }

        public SelectedTheoryQuestion FetchPreviousQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchPreviousQuestion(); };
            _examState.FetchPreviousQuestion(a);
            
            return question;
        }

        public SelectedTheoryQuestion FetchCurrentQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchCurrentQuestion(); };
            _examState.FetchCurrentQuestion(a);

            return question;
        }

        public SelectedTheoryQuestion FetchSpecificQuestion(int index)
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate { question = TheoryComponent.FetchSpecificQuestion(index); };
            _examState.FetchSpecificQuestion(a);
            
            return question;
        }

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
        {
            Action a = delegate { TheoryComponent.AnswerQuestion(questionIndex, selectedAnswers, markForReview); };
            _examState.AnswerQuestion(a);
        }

		public void SubmitTheoryComponent()
		{
			Action a = delegate { ExamStatus = (TheoryComponentCompetency) ? ExamStatus.TheoryComponentCompleted : ExamStatus.TheoryComponentFailed; };
			_examState.SubmitTheoryComponent(a);
		}

		public TheoryComponent FetchTheoryComponentResult()
		{
			Action a = delegate { };
			_examState.FetchTheoryExamResult(a);
			return TheoryComponent;
		}
		
		public void VoidExam()
		{
			Action a = delegate { ExamStatus = ExamStatus.ExamVoided; };
			_examState.VoidExam(a);
		}
		
		//HACK: Reset Theory Component
		public void ResetTheoryComponent()
		{
			ExamStatus = ExamStatus.ExamCreated;
			TheoryComponent.CurrentQuestionIndex = 0;
		}
		
		#endregion

        partial void OnExamStatusIdChanged()
        {
            switch (ExamStatusId)
            {
                case (int)ExamStatus.NoExamCreated:
                    _examState = new NoExamCreated();
                    break;
                case (int)ExamStatus.ExamCreated:
                    _examState = new ExamCreated();
                    break;
                case (int)ExamStatus.TheoryComponentInProgress:
                    _examState = new TheoryComponentInProgress();
                    break;
                case (int)ExamStatus.TheoryComponentFailed:
                    _examState = new TheoryComponentFailed();
                    break;
                case (int)ExamStatus.TheoryComponentCompleted:
                    _examState = new TheoryComponentCompleted();
                    break;
                case (int)ExamStatus.PracticalComponentFailed:
                    _examState = new PracticalComponentFailed();
                    break;
                case (int)ExamStatus.PracticalComponentCompleted:
                    _examState = new PracticalComponentCompleted();
                    break;
                case (int)ExamStatus.ExamCompleted:
                    _examState = new ExamCompleted();
                    break;
                case (int)ExamStatus.ExamVoided:
                    _examState = new ExamVoided();
                    break;
            }
        }
    }
}
