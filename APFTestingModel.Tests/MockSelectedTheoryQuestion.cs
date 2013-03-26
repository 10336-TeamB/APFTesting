using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    internal class MockSelectedTheoryQuestion : ISelectedTheoryQuestion
    {
        public MockSelectedTheoryQuestion(int index)
        {
            QuestionIndex = index;
        }

        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public string Description
        {
            get { return "This is the question description"; }
        }

        public int NumberOfCorrectAnswers
        {
            get { return 1; }
        }

        public IEnumerable<IPossibleAnswer> PossibleAnswers
        {
            get
            {
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
            }
        }

        public int QuestionIndex { get; set; }

        public bool IsMarkedForReview
        {
            get { return false; }
        }

        public bool IsAnswered
        {
            get { return false; }
        }

        public bool IsLastQuestion
        {
            get { return false; }
        }


        public bool IsCorrect
        {
            get { return true; }
        }


        public int TotalNumOfQuestions
        {
            get { return 10; }
        }
    }
}
