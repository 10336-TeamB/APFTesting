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
            this.TheoryFormatId = theoryFormatId;
        }

        private int currentQuestionIndex = 0;

        public Question FetchNextQuestion(ref bool isLastQuestion)
        {
            if (currentQuestionIndex < Questions.Count - 1) {
                isLastQuestion = (Questions.Count - 1 == ++currentQuestionIndex) ? true : false;
            }
            return Questions.ElementAt(currentQuestionIndex);
        }

        public Question FetchPreviousQuestion(ref bool isFirstQuestion)
        {
            if (currentQuestionIndex != 0)
            {
                isFirstQuestion = (--currentQuestionIndex == 0) ? true : false;
            }
            return Questions.ElementAt(currentQuestionIndex);
        }

        public Question FetchQuestion(int index, ref bool isFirstQuestion, ref bool isLastQuestion)
        {
            if (index < 0 || index >= Questions.Count)
            {
                throw new Exception("What are you doing Josh?");
            }
            isFirstQuestion = (index == 0) ? true : false;
            isLastQuestion = (Questions.Count - 1 == index) ? true : false;

            currentQuestionIndex = index;
            return Questions.ElementAt(index);
        }

        public float CalculateResult()
        {
            int correctlyAnswered = 0;

            foreach (var question in Questions) {
                if (question.WasCorrectlyAnswered())
                {
                    ++correctlyAnswered;
                }
            }

            float percentage = (float)correctlyAnswered / TheoryComponentFormat.NumberOfQuestions * 100;

            return percentage;
        }

        public void SelectOption(List<SelectedOption> selectedOptions)
        {
            Questions.ElementAt(currentQuestionIndex).SelectOption(selectedOptions);
        }
    }
}
