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


        //TODO - Why are we using decimal? Why not float? - ADAM
        public decimal Score
		{
			get
			{
				decimal numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.IsCorrect);
				return (numberOfCorrectAnswers / SelectedTheoryQuestions.Count);
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
            //TODO: prevent out of bounds exception - Done (Pradipna)
            if (CurrentQuestionIndex < SelectedTheoryQuestions.Count - 1)
            {
                ++CurrentQuestionIndex;
            }
            
            //TODO: LINQ Query First may throw an exception...
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            
			return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchPreviousQuestion()
		{
            //TODO: prevent out of bounds exception - Done (Pradipna)
            if (CurrentQuestionIndex > 0)
            {
                --CurrentQuestionIndex;
            }
            
            //TODO: LINQ Query First may throw an exception...
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }
			CurrentQuestionIndex = questionIndex;
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.FirstOrDefault(question => question.QuestionIndex == CurrentQuestionIndex);
            
            //Do we even need this check after the first check? - Pradipna
            if (selectedTheoryQuestion == null)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] can not be found.", questionIndex));
            }
            return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchCurrentQuestion()
		{
			return SelectedTheoryQuestions.First(q => q.QuestionIndex == CurrentQuestionIndex);
		}

        public void AnswerQuestion(int questionIndex, int[] selectedAnswers, bool markForReview)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }

            //TODO: LINQ Query First may throw an exception...
			var currentQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == questionIndex);
            currentQuestion.SelectAnswers(selectedAnswers);
            currentQuestion.MarkForReview(markForReview);
		}
		
		

		#endregion
    }
}
