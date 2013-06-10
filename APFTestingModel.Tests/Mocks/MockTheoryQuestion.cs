using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests.Mocks
{
    internal class MockTheoryQuestion : TheoryQuestion
    {
        public MockTheoryQuestion()
        {
        }

        public MockTheoryQuestion(TheoryQuestionDetails questionDetails) : base(questionDetails)
        {
        }
    }
}
