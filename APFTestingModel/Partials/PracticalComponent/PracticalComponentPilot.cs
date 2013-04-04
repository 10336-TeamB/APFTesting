using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentPilot : PracticalComponent, IPracticalComponentPilot
    {
        public PracticalComponentPilot(PracticalComponentTemplate activeTemplate, ICollection<SelectedAssessmentTask> selectedAssessmentTasks) : base(activeTemplate) 
        {
            SelectedAssessmentTasks = selectedAssessmentTasks;
        }

        // TODO - Implement IsCompetent
        public bool IsCompetent
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<ISelectedAssessmentTask> AssessmentTasks
        {
            get { return SelectedAssessmentTasks; }
        }
    }
}
