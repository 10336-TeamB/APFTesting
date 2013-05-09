using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentTemplatePilot : IPracticalComponentTemplatePilot
    {

        public bool AllowEditOrDelete
        {
            get { return PracticalComponentPilots.Count == 0 && !IsActive; }
        }

        public IEnumerable<IAssessmentTaskPilot> Tasks
        {
            get { return AssessmentTaskPilots; }
        }
    }
}
