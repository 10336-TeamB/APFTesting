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

		public override TheoryQuestion CreateTheoryQuestion(TheoryQuestionDetails questionDetails)
		{
			return new TheoryQuestionPacker(questionDetails);
		}


        public override TheoryComponentFormat CreateTheoryExamFormat(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions)
        {
            // validation method declared in the base class
            validateExamFormatDetails(numberOfQuestions, passMark, timeLimit, availableQuestions);
            return new TheoryComponentFormatPacker(numberOfQuestions, passMark, timeLimit);
        }

    }
}
