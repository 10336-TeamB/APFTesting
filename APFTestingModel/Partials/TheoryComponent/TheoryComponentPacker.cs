using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class TheoryComponentPacker
    {
        #region Constructors
        
        public TheoryComponentPacker() { }

        public TheoryComponentPacker(TheoryComponentFormat activeTheoryFormat)
            : base(activeTheoryFormat)
        {

        }

        #endregion
    }
}
