using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class TheoryComponentManagerPacker : TheoryComponentManager
    {
        public TheoryComponentManagerPacker(IEnumerable<TheoryQuestion> theoryQuestionsPacker) : base(theoryQuestionsPacker) { }
        
    }
}
