using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
	internal partial class SelectedTheoryQuestion : ISelectedTheoryQuestion
    {
        #region Constructors

        public SelectedTheoryQuestion(TheoryComponent theoryComponent, TheoryQuestion randomQuestion, int questionIndex)
        {
            // TODO: Complete member initialization
            this.TheoryComponent = theoryComponent;
            this.QuestionIndex = questionIndex;
            this.IsMarkedForReview = false;
            this.TheoryQuestion = randomQuestion;
            SelectedAnswers = TheoryQuestion.PossibleAnswers.Select(pa => new SelectedAnswer(this, pa)).ToArray();
        }

        #endregion

        #region Properties

        public IEnumerable<ISelectedAnswer> ISelectedAnswers
        {
            get
            {
                return this.SelectedAnswers;
            }
        }

        public bool isCorrect
		{
			get
			{
				//Ensures the right number of answers were submitted
				if (SelectedAnswers.Count == TheoryQuestion.NumberOfCorrectAnswers)
				{
					//Checks if submitted answers are all correct
                    return (SelectedAnswers.Count(answer => answer.IsCorrect) == TheoryQuestion.NumberOfCorrectAnswers);
				}
				return false;
			}
		}

        public int NumberOfCorrectAnswers
        {
            get { return TheoryQuestion.NumberOfCorrectAnswers; }
        }

        public string Description
        {
            get { return TheoryQuestion.Description; }
        }

        public bool IsAnswered
        {
            get { return (SelectedAnswers.Count != 0); }
        }

        public IEnumerable<IPossibleAnswer> PossibleAnswers
        {
            get { return TheoryQuestion.PossibleAnswers.OrderBy(pa => pa.DisplayOrderIndex); }
        }

        public bool IsLastQuestion
        {
            get { return QuestionIndex == (TheoryComponent.SelectedTheoryQuestions.Count - 1); }
        }

		#endregion

		#region Methods

        public void SelectAnswers(int[] selectedAnswers)
        {
            foreach (var answer in SelectedAnswers)
            {
                try
                {
                    int index = selectedAnswers.First(i => answer.DisplayOrderIndex == i);
                }
                catch (Exception)
                {
                    answer.IsChecked = false;
                    continue;
                }
                answer.IsChecked = true;
            }
        }
        
        public void MarkForReview(bool isMarked)
        {
            IsMarkedForReview = isMarked;
        }

		#endregion
    }
}
