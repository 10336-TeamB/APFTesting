using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel 
{
    //public enum ExamStatus
    //{
    //    NoExamCreated = 0,
    //    ExamCreated = 1,
    //    TheoryComponentInProgress = 2,
    //    TheoryComponentFailed = 3,
    //    TheoryComponentCompleted = 4,
    //    PracticalComponentFailed = 5,
    //    PracticalComponentCompleted = 6,
    //    ExamCompleted = 7,
    //    ExamVoided = 8,
    //    Count = 8
    //}

    internal abstract partial class Exam : IExam
    {
        protected ExamState _examState;

        #region Constructors

        public Exam() { }

        //REFACTORED
        public Exam(Guid examinerId)
        {
            ExaminerId = examinerId;
            ExamStatus = ExamStatus.NewExam;
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

        //JUST FOR OUR TEST METHOD - Pradipna
        public ExamState ExamState
        {
            get
            {
                return _examState;
            }
        }

        abstract public bool PracticalComponentIsCompetent { get; }

        #endregion

        #region Methods

        public TheoryComponentFormat FetchTheoryComponentFormat()
		{
            TheoryComponentFormat format = null;
            Action a = delegate { format = TheoryComponent.TheoryComponentFormat; };
            _examState.FetchTheoryComponentFormat(a);

            return format;
		}
        
        //REFACTORED
        public SelectedTheoryQuestion FetchFirstQuestion()
        {
            SelectedTheoryQuestion question = null;
            Action a = delegate
            {
                question = TheoryComponent.FetchFirstQuestion();

                ExamStatus = ExamStatus.TheoryInProgress;

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

        //REFACTORED
		public void SubmitTheoryComponent()
		{
			Action a = delegate { ExamStatus = (TheoryComponentCompetency) ? ExamStatus.TheoryPassed : ExamStatus.TheoryFailed; };

			_examState.SubmitTheoryComponent(a);
		}

		public TheoryComponent FetchTheoryComponentResult()
		{
			Action a = delegate { };
			_examState.FetchTheoryExamResult(a);
			return TheoryComponent;
		}
		
        //REFACTORED
		public void VoidExam()
		{

			Action a = delegate { ExamStatus = ExamStatus.ExamVoided; };

			_examState.VoidExam(a);
		}
		
		//HACK: Reset Theory Component - Remove for production
		public void ResetTheoryComponent()
		{
            TheoryComponent.SelectedTheoryQuestions.ToList()
                .ForEach(q =>
                {
                    q.PossibleAnswers.ToList().ForEach(pa => pa.IsChecked = false);
                    q.IsMarkedForReview = false;
                });
			ExamStatus = ExamStatus.NewExam;

			TheoryComponent.CurrentQuestionIndex = 0;
		}
		
		#endregion


        partial void OnExamStatusChanged()
        {
            switch (ExamStatus)
            {
                case ExamStatus.NoExam:
                    _examState = new NoExamCreated();
                    break;
                case ExamStatus.NewExam:
                    _examState = new ExamCreated();
                    break;
                case ExamStatus.TheoryInProgress:
                    _examState = new TheoryComponentInProgress();
                    break;
                case ExamStatus.TheoryFailed:
                    _examState = new TheoryComponentFailed();
                    break;
                case ExamStatus.TheoryPassed:
                    _examState = new TheoryComponentCompleted();
                    break;
                case ExamStatus.PracticalEntered:
                    _examState = new PracticalComponentCompleted();
                    break;
                case ExamStatus.ExamCompleted:
                    _examState = new ExamCompleted();
                    break;
                case ExamStatus.ExamVoided:
                    _examState = new ExamVoided();
                    break;
            }
        }
    }
}
