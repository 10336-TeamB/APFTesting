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
				var numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.isCorrect == true);
				
				return (numberOfCorrectAnswers / SelectedTheoryQuestions.Count) * 100;
			}
		}

		public bool IsCompetent
		{
			get
			{
				if (Score >= TheoryComponentFormat.PassMark)
				{
					return true;
				}
				
				return false;
			}
		}

        IEnumerable<ISelectedTheoryQuestion> ITheoryComponent.SelectedTheoryQuestions
        {
            get { return (IEnumerable<ISelectedTheoryQuestion>)SelectedTheoryQuestions; }
        }

		#endregion



		#region Methods

       

		public SelectedTheoryQuestion FetchNextQuestion(ref bool isLastQuestion)
		{
            //TODO: prevent out of bounds exception
            ++CurrentQuestionIndex;
			isLastQuestion = (CurrentQuestionIndex == (SelectedTheoryQuestions.Count - 1));
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            selectedTheoryQuestion.checkPossibleAnswers();
			return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchPreviousQuestion(ref bool isFirstQuestion)
		{
            //TODO: prevent out of bounds exception
            --CurrentQuestionIndex;
			isFirstQuestion = (CurrentQuestionIndex == 0);
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            selectedTheoryQuestion.checkPossibleAnswers();
            return selectedTheoryQuestion;
		}

		public SelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleExcpetion("Question Index Invalid");
            }
			CurrentQuestionIndex = questionIndex;
            SelectedTheoryQuestion selectedTheoryQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
            selectedTheoryQuestion.checkPossibleAnswers();
            return selectedTheoryQuestion;
		}

		public void SelectAnswers(List<Guid> possibleAnswerIds, bool isMarkedForReview)
		{
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
