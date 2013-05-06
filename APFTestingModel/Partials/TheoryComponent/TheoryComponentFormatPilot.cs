using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class TheoryComponentFormatPilot
	{
        public TheoryComponentFormatPilot() { }

        public TheoryComponentFormatPilot(int numberOfQuestions, int passMark, int timeLimit) 
            : base(numberOfQuestions, passMark, timeLimit) { }
	}
}
