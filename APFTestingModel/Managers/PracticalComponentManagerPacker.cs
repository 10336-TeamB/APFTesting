using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal class PracticalComponentManagerPacker : PracticalComponentManager
    {
        public PracticalComponentManagerPacker() { }
        public PracticalComponentManagerPacker(PracticalComponentTemplate activeTemplate) : base(activeTemplate) { }

        public override PracticalComponent GeneratePracticalComponent()
        {
            PracticalComponentPacker practicalComponentPacker = new PracticalComponentPacker(activeTemplate);
            return practicalComponentPacker;
        }

        public PracticalComponentTemplatePacker CreatePracticalComponentTemplatePacker(int NumOfRequiredAssessmentTasks)
        {
            if (NumOfRequiredAssessmentTasks < 1)
            {
                throw new BusinessRuleException("Practical Assessment must include at least 1 assessment task");
            }
            return new PracticalComponentTemplatePacker(NumOfRequiredAssessmentTasks);
        }
    }
}
