using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentPacker : PracticalComponent, IPracticalComponentPacker
    {
        public PracticalComponentPacker(PracticalComponentTemplate activeTemplate) 
        {
            PracticalComponentTemplatePacker = (PracticalComponentTemplatePacker)activeTemplate;
        }

        // TODO - Implement IsCompetent
        public bool IsCompetent
        {
            get 
            {
                return (AssessmentTaskPackers.Count >= PracticalComponentTemplatePacker.NumOfRequiredAssessmentTasks);
            }
        }

        public int NumOfRequiredAssessmentTasks
        {
            get { return PracticalComponentTemplatePacker.NumOfRequiredAssessmentTasks; }
        }

        public IEnumerable<IAssessmentTaskPacker> AssessmentTasks
        {
            get { return AssessmentTaskPackers; }
        }
    }
}
