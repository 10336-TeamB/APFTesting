using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class SelectedTheoryQuestion : ISelectedTheoryQuestion
	{

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

        public ITheoryComponent Component
        {
            get { return TheoryComponent; }
        }

        public ITheoryQuestion Question
        {
            get { return TheoryQuestion; }
        }

        IEnumerable<ISelectedAnswer> ISelectedTheoryQuestion.SelectedAnswers
        {
            get { return (IEnumerable<ISelectedAnswer>)SelectedAnswers; }
        }

		#endregion



		#region Methods

		public void selectAnswer(List<Guid> possibleAnswerIds)
		{
			foreach (var possibleAnswerId in possibleAnswerIds)
			{
				SelectedAnswers.Add(new SelectedAnswer(this.Id, possibleAnswerId));
			}
		}

		#endregion




        
    }
}
