﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPilot : TheoryComponentManager
    {
        public TheoryComponentManagerPilot(IEnumerable<TheoryQuestion> theoryQuestionsPilot, TheoryComponentFormat activeTheoryFormat) : base(theoryQuestionsPilot, activeTheoryFormat) { }

        public override TheoryComponent GenerateTheoryComponent()
        {
            TheoryComponentPilot theoryComponent = new TheoryComponentPilot(activeFormat);
            theoryComponent.SelectedTheoryQuestions = FetchRandomQuestions(activeFormat.NumberOfQuestions, theoryComponent);
            return theoryComponent;
        }
    }
}