using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPacker : TheoryComponentManager
    {
        public TheoryComponentManagerPacker() { }

        public TheoryComponentManagerPacker(IEnumerable<TheoryQuestion> theoryQuestionsPacker, TheoryComponentFormat activeTheoryFormat) : base(theoryQuestionsPacker, activeTheoryFormat) { }

        public override TheoryComponent GenerateTheoryComponent()
        {
            TheoryComponentPacker theoryComponent = new TheoryComponentPacker(activeFormat);
            theoryComponent.SelectedTheoryQuestions = FetchRandomQuestions(activeFormat.NumberOfQuestions, theoryComponent);
            return theoryComponent;
        }

        public override TheoryComponentFormat CreateTheoryExamFormat(int numberOfQuestions, int passMark, int timeLimit)
        {
            return new TheoryComponentFormatPacker(numberOfQuestions, passMark, timeLimit);
        }
    }
}
