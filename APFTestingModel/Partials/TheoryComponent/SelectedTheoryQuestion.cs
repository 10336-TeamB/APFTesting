using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APFTestingModel
{
	internal partial class SelectedTheoryQuestion : ISelectedTheoryQuestion
	{
        private APFTestingModel.TheoryQuestion randomQuestion;

        public SelectedTheoryQuestion(TheoryComponent theoryComponent, TheoryQuestion randomQuestion, int questionIndex)
        {
            // TODO: Complete member initialization
            this.TheoryComponent = theoryComponent;
            this.randomQuestion = randomQuestion;
            this.QuestionIndex = questionIndex;
            this.IsMarkedForReview = false;
        }

		#region Properties

		public bool isCorrect
		{
			get
			{
				//Ensures the right number of answers were submitted
				if (SelectedAnswers.Count == TheoryQuestion.NumberOfCorrectAnswers)
				{
					//Checks if submitted answers are all correct
                    return (SelectedAnswers.Count(answer => answer.IsCorrect == true) == TheoryQuestion.NumberOfCorrectAnswers);
					
				}

				return false;
			}
		}

        //public ITheoryComponent Component
        //{
        //    get { return TheoryComponent; }
        //}

        //public ITheoryQuestion Question
        //{
        //    get { return TheoryQuestion; }
        //}

        public string Description
        {
            get
            {
                return TheoryQuestion.Description;
            }
        }

        //IEnumerable<ISelectedAnswer> ISelectedTheoryQuestion.SelectedAnswers
        //{
        //    get { return (IEnumerable<ISelectedAnswer>)SelectedAnswers; }
        //}

        public bool IsAnswered
        {
            get
            {
                return (SelectedAnswers.Count == 0) ? false : true;
            }
        }

        public IEnumerable<IPossibleAnswer> PossibleAnswers
        {
            get
            {
                return TheoryQuestion.PossibleAnswers;
            }
        }

		#endregion



		#region Methods


        public void SelectAnswers(List<Guid> possibleAnswerIds)
        {
            SelectedAnswers.Clear();
            foreach (var possibleAnswerId in possibleAnswerIds)
            {
                SelectedAnswers.Add(new SelectedAnswer(this.Id, possibleAnswerId));
            }
        }

        public void checkPossibleAnswers()
        {
            foreach (var answer in SelectedAnswers)
            {
                answer.PossibleAnswer.IsChecked = true;
            }
        }

		#endregion




        
    }
}
