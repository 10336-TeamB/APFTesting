using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public partial class TheoryQuestion : ITheoryQuestion
    {
        public bool WasCorrectlyAnswered()
        {
            int numOfCorrectlySelected = 0;

            foreach (var selectedAnswer in SelectedAnswers)
            {
                if (selectedAnswer.PossibleAnswer.IsCorrect)
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

        public void SelectOption(List<SelectedAnswer> selectedOptions)
        {
            SelectedAnswers = selectedOptions;
        }


        IEnumerable<IPossibleAnswer> ITheoryQuestion.PossibleAnswers
        {
            get { return PossibleAnswers; }
        }

        public int QuestionNumber
        {
            get { throw new NotImplementedException(); }
        }
    }
}
