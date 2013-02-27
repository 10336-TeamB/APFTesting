using APFTestingModel.Interfaces;
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
        }

        public TheoryQuestion(ITheoryQuestion question)
        {
            Description = question.Description;
            QuestionNumber = question.QuestionNumber;
            PossibleAnswers = question.PossibleAnswers.Select(pa => new PossibleAnswer(pa));
            NumCorrectAnswers = question.NumberOfCorrectAnswer;
        }

        public string Description { get; set; }
        public int QuestionNumber { get; set; }
        public IEnumerable<PossibleAnswer> PossibleAnswers { get; set; }
        public List<int> SelectedOptions { get; set; }
        public int NumCorrectAnswers { get; set; }

        private IEnumerable<PossibleAnswer> createMockAnswerList()
        {
            yield return new PossibleAnswer { Description = "First option", Order = 1 };
            yield return new PossibleAnswer { Description = "Second option", Order = 2 };
            yield return new PossibleAnswer { Description = "Third option", Order = 3 };
            yield return new PossibleAnswer { Description = "Fourth option", Order = 4 };
        }
    }
}