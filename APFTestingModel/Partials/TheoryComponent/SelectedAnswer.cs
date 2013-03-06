using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class SelectedAnswer
	{

		#region Properties

		public bool IsCorrect
		{
			get
			{
				return PossibleAnswer.IsCorrect;
			}
		}

		#endregion


		#region Methods

		public SelectedAnswer(Guid selectedTheoryQuestionId, Guid possibleAnswerId)
		{
			SelectedTheoryQuestionId = selectedTheoryQuestionId;
			PossibleAnswerId = possibleAnswerId;
		}
		
		#endregion

		
    }
}
