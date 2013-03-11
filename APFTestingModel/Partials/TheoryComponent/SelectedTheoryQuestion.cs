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

        IEnumerable<ISelectedAnswer> ISelectedTheoryQuestion.SelectedAnswers
        {
            get { return SelectedAnswers.OrderBy(a => a.DisplayOrderIndex); }
        }

        //TODO: This is now broken because of new implementation of SelectedAnswers.
        public bool IsCorrect
		{
			get
			{
			    if (SelectedAnswers.Any(sa => sa.IsCorrect == false))
			    {
			        return false;
			    }
			    return true;
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
            get { return (SelectedAnswers.Any(sa => sa.IsChecked)); }
        }

        public bool IsLastQuestion
        {
            get { return QuestionIndex == (TheoryComponent.SelectedTheoryQuestions.Count - 1); }
        }

		#endregion

		#region Methods

        public void SelectAnswers(int[] selectedAnswers)
        {
            if (selectedAnswers == null)
            {
                SelectedAnswers.ToList().ForEach(sa => sa.IsChecked = false);
            }
            else
            {
                foreach (var answer in SelectedAnswers)
                {
                    answer.IsChecked = (Array.Exists(selectedAnswers, a => a == answer.DisplayOrderIndex));
                }
            }
        }
        
        public void MarkForReview(bool isMarked)
        {
            IsMarkedForReview = isMarked;
        }

		#endregion
    }
}
