using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class TheoryComponentFormatPacker
	{
        public TheoryComponentFormatPacker()
        {
        }

        public TheoryComponentFormatPacker(int numberOfQuestions, int passMark)
        {
            NumberOfQuestions = numberOfQuestions;
            PassMark = passMark;
        }
	}
}
