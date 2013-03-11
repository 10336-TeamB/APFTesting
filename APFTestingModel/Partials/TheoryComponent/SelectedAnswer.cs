﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class SelectedAnswer : ISelectedAnswer
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
            get { return PossibleAnswer.IsCorrect == IsChecked; }
		}

        public int DisplayOrderIndex
        {
            get
            {
                return PossibleAnswer.DisplayOrderIndex;
            }
        }

        public string Description
        {
            get
            {
                return PossibleAnswer.Description;
            }
        }

		#endregion


		#region Methods

		
		
		#endregion
    }
}
