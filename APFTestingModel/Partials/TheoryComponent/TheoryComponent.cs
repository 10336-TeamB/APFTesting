using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryComponent : ITheoryComponent, ITheoryComponentResult
    {

        public TheoryComponent(TheoryComponentFormat activeTheoryFormat)
        {
            TheoryComponentFormat = activeTheoryFormat;
        }

		#region Properties

		public decimal Score
		{
			get
			{
				var numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.isCorrect);
				
				return (numberOfCorrectAnswers / SelectedTheoryQuestions.Count) * 100;
			}
		}

		public bool IsCompetent
		{
			get { return (Score >= TheoryComponentFormat.PassMark); }
		}

        IEnumerable<ISelectedTheoryQuestion> ITheoryComponent.SelectedTheoryQuestions
        {
            get { return SelectedTheoryQuestions; }
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
            
            //What is checkPossibleAnswers doing? - ADAM
            selectedTheoryQuestion.checkPossibleAnswers();
			return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchPreviousQuestion()
		{
            //TODO: prevent out of bounds exception
            --CurrentQuestionIndex;
            
            //Should no longer need this - ADAM
			//isFirstQuestion = (CurrentQuestionIndex == 0);

            //TODO: LINQ Query First may throw an exception...
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            //What is checkPossibleAnswers doing? - ADAM
            selectedTheoryQuestion.checkPossibleAnswers();
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
            selectedTheoryQuestion.checkPossibleAnswers();
            return selectedTheoryQuestion;
		}

		public void SelectAnswers(List<Guid> possibleAnswerIds, bool isMarkedForReview)
		{
            //TODO: LINQ Query First may throw an exception...
			var currentQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
			currentQuestion.SelectAnswers(possibleAnswerIds);
            if (isMarkedForReview)
            {
                markQuestionForReview(currentQuestion);
            }
		}

        private void markQuestionForReview(SelectedTheoryQuestion question)
        {
            question.IsMarkedForReview = true;
        }

		#endregion
    }
}
