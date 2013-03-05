using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class TheoryComponent
    {
        // Commented out to allow compilation
        //public TheoryComponent(Guid examinerId, Guid theoryFormatId)
        //{
        //    this.FormatId = theoryFormatId;
        //}

        //private int currentQuestionIndex = 0;

        //public TheoryComponent(TheoryComponentFormat format, Examiner examiner, ICollection<TheoryQuestion> randomQuestions)
        //{
        //    TheoryComponentFormat = format;			
        //    Examiner = examiner;
        //    SelectedTheoryQuestions = randomQuestions;
			
        //}

        //public TheoryQuestion FetchNextQuestion(ref bool isLastQuestion)
        //{
        //    if (currentQuestionIndex < SelectedTheoryQuestions.Count - 1)
        //    {
        //        isLastQuestion = (SelectedTheoryQuestions.Count - 1 == ++currentQuestionIndex) ? true : false;
        //    }
        //    return SelectedTheoryQuestions.ElementAt(currentQuestionIndex);
        //}

        //public TheoryQuestion FetchPreviousQuestion(ref bool isFirstQuestion)
        //{
        //    if (currentQuestionIndex != 0)
        //    {
        //        isFirstQuestion = (--currentQuestionIndex == 0) ? true : false;
        //    }
        //    return SelectedTheoryQuestions.ElementAt(currentQuestionIndex);
        //}

        //public TheoryQuestion FetchQuestion(int index, ref bool isFirstQuestion, ref bool isLastQuestion)
        //{
        //    if (index < 0 || index >= SelectedTheoryQuestions.Count)
        //    {
        //        throw new Exception("What are you doing Josh?");
        //    }
        //    isFirstQuestion = (index == 0) ? true : false;
        //    isLastQuestion = (SelectedTheoryQuestions.Count - 1 == index) ? true : false;

        //    currentQuestionIndex = index;
        //    return SelectedTheoryQuestions.ElementAt(index);
        //}

        //public float CalculateResult()
        //{
        //    int correctlyAnswered = 0;

        //    foreach (var question in SelectedTheoryQuestions)
        //    {
        //        if (question.WasCorrectlyAnswered())
        //        {
        //            ++correctlyAnswered;
        //        }
        //    }

        //    float percentage = (float)correctlyAnswered / TheoryComponentFormat.NumberOfQuestions * 100;

        //    return percentage;
        //}

        // Commented out to allow compilation
        //public void SelectOption(List<SelectedAnswer> selectedOptions)
        //{
        //    SelectedTheoryQuestions.ElementAt(currentQuestionIndex).SelectOption(selectedOptions);
        //}
    }
}
