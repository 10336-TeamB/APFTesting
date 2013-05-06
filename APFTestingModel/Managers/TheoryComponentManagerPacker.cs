using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPacker : TheoryComponentManager
    {
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
    }
}
