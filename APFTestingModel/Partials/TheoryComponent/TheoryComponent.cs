using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryComponent : ITheoryComponent
    {
        #region Constructors

        public TheoryComponent(TheoryComponentFormat activeTheoryFormat)
        {
            TheoryComponentFormat = activeTheoryFormat;
        }

        #endregion

        #region Properties

        public float Score
		{
			get
			{
				float numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.IsCorrect);
				return (numberOfCorrectAnswers / SelectedTheoryQuestions.Count);
			}
		}

        public int NumberOfCorrectlyAnsweredQuestions
        {
            get
            {
                return SelectedTheoryQuestions.Count(question => question.IsCorrect);
            }
        }

		public bool IsCompetent
		{
			get { return ((Score * 100.0) >= TheoryComponentFormat.PassMark); }
		}

        IEnumerable<ISelectedTheoryQuestion> ITheoryComponent.SelectedTheoryQuestions
        {
            get { return SelectedTheoryQuestions.OrderBy(q => q.QuestionIndex); }
        }

        public int NumberOfQuestions
        {
            get
            {
                return TheoryComponentFormat.NumberOfQuestions;
            }
        }

		#endregion

		#region Methods

        public SelectedTheoryQuestion FetchFirstQuestion()
        {
            if (CurrentQuestionIndex == 0)
            {
                return SelectedTheoryQuestions.First(q => q.QuestionIndex == 0);
            }
            else
            {
                throw new BusinessRuleException("Not permitted to fetch first question when current question index is beyond first question");
            }
            
        }

		public SelectedTheoryQuestion FetchNextQuestion()
		{
            if (CurrentQuestionIndex < SelectedTheoryQuestions.Count - 1)
            {
                ++CurrentQuestionIndex;
            }
            
            return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

		public SelectedTheoryQuestion FetchPreviousQuestion()
		{
            if (CurrentQuestionIndex > 0)
            {
                --CurrentQuestionIndex;
            }

            return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

        public SelectedTheoryQuestion FetchCurrentQuestion()
        {
            return SelectedTheoryQuestions.First(q => q.QuestionIndex == CurrentQuestionIndex);
        }

		public SelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }
			CurrentQuestionIndex = questionIndex;

            return SelectedTheoryQuestions.FirstOrDefault(question => question.QuestionIndex == CurrentQuestionIndex);
		}

        public void AnswerQuestion(int questionIndex, int[] answerIndexes, bool markForReview)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }

            var currentQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == questionIndex);
            currentQuestion.SelectAnswers(answerIndexes);
            currentQuestion.MarkForReview(markForReview);
		}

		#endregion
    }
}
