using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PossibleAnswer : IPossibleAnswer
	{

        #region Constructors

        public PossibleAnswer() { }

        public PossibleAnswer(SelectedTheoryQuestion selectedTheoryQuestion, Answer answer)
        {
            SelectedTheoryQuestion = selectedTheoryQuestion;
            Answer = answer;
            SelectedTime = DateTime.Now;
        }

        #endregion

		#region Properties

		public bool IsCorrect
		{
            get { return Answer.IsCorrect == IsChecked; }
		}

        public int DisplayOrderIndex
        {
            get
            {
                return Answer.DisplayOrderIndex;
            }
        }

        public string Description
        {
            get
            {
                return Answer.Description;
            }
        }

		#endregion


		#region Methods

		
		
		#endregion
    }
}
