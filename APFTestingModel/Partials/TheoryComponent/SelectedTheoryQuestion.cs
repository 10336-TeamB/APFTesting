using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
	internal partial class SelectedTheoryQuestion : ISelectedTheoryQuestion, IComparable
    {
        #region Constructors

        public SelectedTheoryQuestion(TheoryComponent theoryComponent, TheoryQuestion randomQuestion, int questionIndex)
        {
            // TODO: Complete member initialization
            this.TheoryComponent = theoryComponent;
            this.QuestionIndex = questionIndex;
            this.IsMarkedForReview = false;
            this.TheoryQuestion = randomQuestion;
            PossibleAnswers = TheoryQuestion.Answers.Select(a => new PossibleAnswer(this, a)).ToArray();
        }

        #endregion

        #region Properties

        IEnumerable<IPossibleAnswer> ISelectedTheoryQuestion.PossibleAnswers
        {
            get { return PossibleAnswers.OrderBy(a => a.DisplayOrderIndex); }
        }

        public bool IsCorrect
		{
			get
			{
                if (PossibleAnswers.Any(pa => pa.IsCorrect == false))
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
            get { return (PossibleAnswers.Any(sa => sa.IsChecked)); }
        }

        public bool IsLastQuestion
        {
            get { return QuestionIndex == (TheoryComponent.SelectedTheoryQuestions.Count - 1); }
        }

        public int TotalNumOfQuestions
        {
            get { return TheoryComponent.SelectedTheoryQuestions.Count; }
        }

        public string ImagePath
        {
            get { return TheoryQuestion.ImagePath; }
        }

        public ExamType ExamType
        {
            get
            {
                if (TheoryComponent is TheoryComponentPilot)
                {
                    return ExamType.PilotExam;
                }
                else if (TheoryComponent is TheoryComponentPacker)
                {
                    return ExamType.PackerExam;
                }
                else
                {
                    throw new BusinessRuleException("Exam Type not defined");
                }
            }
        }

		#endregion

		#region Methods

        public void SelectAnswers(int[] possibleAnswers)
        {
            if (possibleAnswers == null)
            {
                PossibleAnswers.ToList().ForEach(sa => sa.IsChecked = false);
            }
            else
            {
                foreach (var answer in PossibleAnswers)
                {
                    answer.IsChecked = (Array.Exists(possibleAnswers, a => a == answer.DisplayOrderIndex));
                }
            }
        }
        
        public void MarkForReview(bool isMarked)
        {
            IsMarkedForReview = isMarked;
        }

		#endregion

        public int CompareTo(object stq)
        {
            if (this.QuestionIndex == (stq as SelectedTheoryQuestion).QuestionIndex)
            {
                return 0;
            }
            else if (this.QuestionIndex < (stq as SelectedTheoryQuestion).QuestionIndex)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
