using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class PracticalComponentManagerPacker : PracticalComponentManager
    {
        public PracticalComponentManagerPacker(PracticalComponentTemplate activeTemplate) : base(activeTemplate) { }

        public override PracticalComponent GeneratePracticalComponent()
        {
            PracticalComponentPacker practicalComponentPacker = new PracticalComponentPacker(activeTemplate);
            return practicalComponentPacker;
        }
    }
}
