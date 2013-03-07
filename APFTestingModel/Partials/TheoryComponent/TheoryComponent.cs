using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryComponent : ITheoryComponent, ITheoryComponentResult
    {

        public TheoryComponent(List<SelectedTheoryQuestion> selectedTheoryQuestions)
        {
            SelectedTheoryQuestions = selectedTheoryQuestions;
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

			return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

		public SelectedTheoryQuestion FetchPreviousQuestion(ref bool isFirstQuestion)
		{
            //TODO: prevent out of bounds exception
            --CurrentQuestionIndex;
			isFirstQuestion = (CurrentQuestionIndex == 0);
            
			return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

		public SelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= SelectedTheoryQuestions.Count)
            {
                throw new BusinessRuleExcpetion("Question Index Invalid");
            }
			CurrentQuestionIndex = questionIndex;
			return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
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
