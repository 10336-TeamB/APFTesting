﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class TheoryComponentPilot : TheoryComponent
	{
        public TheoryComponentPilot() { }

        public TheoryComponentPilot(TheoryComponentFormat activeTheoryFormat)
            : base(activeTheoryFormat)
        {

        }
	}
}
