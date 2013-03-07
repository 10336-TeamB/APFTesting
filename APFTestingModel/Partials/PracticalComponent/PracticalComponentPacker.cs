using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentPacker : PracticalComponent, IPracticalComponentPacker
    {
        public PracticalComponentPacker(PracticalComponentTemplate activeTemplate) : base(activeTemplate) { }

        // TODO - Implement IsCompetent
        public bool IsCompetent
        {
            get { throw new NotImplementedException(); }
        }

        public int NumOfRequiredAssessmentTasks
        {
            get { return (PracticalComponentTemplate as PracticalComponentTemplatePacker).NumOfRequiredAssessmentTasks; }
        }

        public IEnumerable<IAssessmentTaskPacker> AssessmentTasks
        {
            get { return AssessmentTaskPackers; }
        }
    }
}
