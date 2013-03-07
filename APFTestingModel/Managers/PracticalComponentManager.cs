using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    abstract internal class PracticalComponentManager
    {
        protected PracticalComponentTemplate activeTemplate;

        public abstract PracticalComponent GeneratePracticalComponent();

        public PracticalComponentManager(PracticalComponentTemplate activeTemplate)
        {
            this.activeTemplate = activeTemplate;
        }
    }
}
