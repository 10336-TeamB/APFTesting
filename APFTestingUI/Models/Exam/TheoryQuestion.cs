using APFTestingModel;
using System.Collections.Generic;
using System.Linq;

namespace APFTestingUI.Models.Exam
{
    public class TheoryQuestion
    {
        public TheoryQuestion()
        {
            Description = "This is an example question";
            QuestionNumber = 1;
            PossibleAnswers = createMockAnswerList();
            NumCorrectAnswers = 1;
        }

        public TheoryQuestion(ISelectedTheoryQuestion question)
        {
            Description = question.Description;
            //What's Question number? Do we even need it?
            //QuestionNumber = question.QuestionNumber;
            PossibleAnswers = question.ISelectedAnswers.Select(pa => new PossibleAnswer(pa));
            NumCorrectAnswers = question.NumberOfCorrectAnswers;
        }

        public string Description { get; set; }
        public int QuestionNumber { get; set; }
        public IEnumerable<PossibleAnswer> PossibleAnswers { get; set; }
        public List<int> SelectedAnswer { get; set; }
        public int NumCorrectAnswers { get; set; }

        private IEnumerable<PossibleAnswer> createMockAnswerList()
        {
            yield return new PossibleAnswer { Description = "First option", DisplayOrderIndex = 1 };
            yield return new PossibleAnswer { Description = "Second option", DisplayOrderIndex = 2 };
            yield return new PossibleAnswer { Description = "Third option", DisplayOrderIndex = 3 };
            yield return new PossibleAnswer { Description = "Fourth option", DisplayOrderIndex = 4 };
        }
    }
}