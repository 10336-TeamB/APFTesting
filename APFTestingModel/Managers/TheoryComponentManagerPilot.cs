using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPilot : TheoryComponentManager
    {
        public TheoryComponentManagerPilot() { }

        public TheoryComponentManagerPilot(IEnumerable<TheoryQuestion> theoryQuestionsPilot, TheoryComponentFormat activeTheoryFormat) : base(theoryQuestionsPilot, activeTheoryFormat) { }

        public override TheoryComponent GenerateTheoryComponent()
        {
            TheoryComponentPilot theoryComponent = new TheoryComponentPilot(activeFormat);
            theoryComponent.SelectedTheoryQuestions = FetchRandomQuestions(activeFormat.NumberOfQuestions, theoryComponent);
            return theoryComponent;
        }

		public override TheoryQuestion CreateTheoryQuestion(TheoryQuestionDetails questionDetails)
		{
			return new TheoryQuestionPilot(questionDetails);
		}
		
        public override TheoryComponentFormat CreateTheoryExamFormat(int numberOfQuestions, int passMark, int timeLimit)
        {
            return new TheoryComponentFormatPilot(numberOfQuestions, passMark, timeLimit);
        }

    }
}
