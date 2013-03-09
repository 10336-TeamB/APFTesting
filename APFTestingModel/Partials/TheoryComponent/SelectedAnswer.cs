using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class SelectedAnswer
	{

        #region Constructors

        public SelectedAnswer() { }

        public SelectedAnswer(SelectedTheoryQuestion selectedTheoryQuestion, PossibleAnswer possibleAnswer)
        {
            SelectedTheoryQuestion = selectedTheoryQuestion;
            PossibleAnswer = possibleAnswer;
            SelectedTime = DateTime.Now;
        }

        #endregion

		#region Properties

		public bool IsCorrect
		{
			get { return PossibleAnswer.IsCorrect; }
		}

		#endregion


		#region Methods

		
		
		#endregion
    }
}
