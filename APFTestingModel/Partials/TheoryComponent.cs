using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public partial class TheoryComponent
    {
        public TheoryComponent(Guid examinerId, Guid theoryFormatId)
        {
            this.ExaminerId = examinerId;
            this.FormatId = theoryFormatId;
        }

        private int currentQuestionIndex = 0;

		public TheoryComponent(TheoryComponentFormat format, Examiner examiner, ICollection<TheoryQuestion> randomQuestions)
		{
			TheoryComponentFormat = format;			
            Examiner = examiner;
			TheoryQuestions = randomQuestions;
			
		}

        public TheoryQuestion FetchNextQuestion(ref bool isLastQuestion)
        {
            if (currentQuestionIndex < TheoryQuestions.Count - 1)
            {
                isLastQuestion = (TheoryQuestions.Count - 1 == ++currentQuestionIndex) ? true : false;
            }
            return TheoryQuestions.ElementAt(currentQuestionIndex);
        }

        public TheoryQuestion FetchPreviousQuestion(ref bool isFirstQuestion)
        {
            if (currentQuestionIndex != 0)
            {
                isFirstQuestion = (--currentQuestionIndex == 0) ? true : false;
            }
            return TheoryQuestions.ElementAt(currentQuestionIndex);
        }

        public TheoryQuestion FetchQuestion(int index, ref bool isFirstQuestion, ref bool isLastQuestion)
        {
            if (index < 0 || index >= TheoryQuestions.Count)
            {
                throw new Exception("What are you doing Josh?");
            }
            isFirstQuestion = (index == 0) ? true : false;
            isLastQuestion = (TheoryQuestions.Count - 1 == index) ? true : false;

            currentQuestionIndex = index;
            return TheoryQuestions.ElementAt(index);
        }

        public float CalculateResult()
        {
            int correctlyAnswered = 0;

            foreach (var question in TheoryQuestions)
            {
                if (question.WasCorrectlyAnswered())
                {
                    ++correctlyAnswered;
                }
            }

            float percentage = (float)correctlyAnswered / TheoryComponentFormat.NumberOfQuestions * 100;

            return percentage;
        }

        public void SelectOption(List<SelectedAnswer> selectedOptions)
        {
            TheoryQuestions.ElementAt(currentQuestionIndex).SelectOption(selectedOptions);
        }
    }
}
