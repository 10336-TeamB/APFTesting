using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Question
    {
        public bool WasCorrectlyAnswered()
        {
            int numOfCorrectlySelected = 0;

            foreach (var selectionOption in SelectedOptions)
            {
                if (selectionOption.PossibleAnswer.IsCorrect)
                {
                    ++numOfCorrectlySelected;
                }
                else
                {
                    return false;
                }
            }

            return (numOfCorrectlySelected == NumberOfCorrectAnswer) ? true : false ;
        }

        public void SelectOption(List<SelectedOption> selectedOptions)
        {
            SelectedOptions = selectedOptions;
        }
    }
}
