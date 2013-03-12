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

        public decimal Score
		{
			get
			{
				decimal numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.IsCorrect);
				return (numberOfCorrectAnswers / SelectedTheoryQuestions.Count) * 100;
			}
		}

		public bool IsCompetent
		{
			get { return (Score >= TheoryComponentFormat.PassMark); }
		}

        IEnumerable<ISelectedTheoryQuestion> ITheoryComponent.SelectedTheoryQuestions
        {
            get { return SelectedTheoryQuestions.OrderBy(q => q.QuestionIndex); }
        }

		#endregion

		#region Methods

		public SelectedTheoryQuestion FetchNextQuestion()
		{
            //TODO: prevent out of bounds exception
            ++CurrentQuestionIndex;
            //Should no longer need this - ADAM
			//isLastQuestion = (CurrentQuestionIndex == (SelectedTheoryQuestions.Count - 1));
            
            //TODO: LINQ Query First may throw an exception...
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            
			return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchPreviousQuestion()
		{
            //TODO: prevent out of bounds exception
            --CurrentQuestionIndex;
            
            //TODO: LINQ Query First may throw an exception...
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleExcpetion(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }
			CurrentQuestionIndex = questionIndex;
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.FirstOrDefault(question => question.QuestionIndex == CurrentQuestionIndex);
            if (selectedTheoryQuestion == null)
            {
                throw new BusinessRuleExcpetion(String.Format("Question Index [{0}] can not be found.", questionIndex));
            }
            return selectedTheoryQuestion;
		}

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
		{
            //TODO: LINQ Query First may throw an exception...
			var currentQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == questionIndex);
            currentQuestion.SelectAnswers(selectedAnswers);
            currentQuestion.MarkForReview(markForReview);
		}

		#endregion
    }
}
