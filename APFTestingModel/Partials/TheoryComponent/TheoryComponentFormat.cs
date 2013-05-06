using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryComponentFormat : ITheoryComponentFormat
    {
        public TheoryComponentFormat(int numberOfQuestions, int passMark, int timeLimit)
        {
            NumberOfQuestions = numberOfQuestions;
            PassMark = passMark;
            TimeLimit = timeLimit;
        }
    }
}
