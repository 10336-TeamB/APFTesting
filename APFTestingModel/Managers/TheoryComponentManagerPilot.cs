using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPilot : TheoryComponentManager
    {
        public TheoryComponentManagerPilot(IEnumerable<TheoryQuestion> theoryQuestionsPilot) : base(theoryQuestionsPilot) { }
    }
}
