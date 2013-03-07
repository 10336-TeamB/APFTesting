using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class PracticalComponentManagerPilot : PracticalComponentManager
    {
        public PracticalComponentManagerPilot(PracticalComponentTemplate activeTemplate) : base(activeTemplate) { }

        public override PracticalComponent GeneratePracticalComponent()
        {
            PracticalComponentPilot practicalComponentPilot = new PracticalComponentPilot(activeTemplate);
            return practicalComponentPilot;
        }
    }
}
