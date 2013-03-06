using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal class SelectedTheoryQuestion
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
					if (SelectedAnswers.Count(answer => answer.IsCorrect) == TheoryQuestion.NumberOfCorrectAnswers)
					{
						return true;
					}
				}

				return false;
			}
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
