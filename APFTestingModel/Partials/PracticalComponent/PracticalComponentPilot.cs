using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentPilot : PracticalComponent, IPracticalComponentPilot
    {
        public PracticalComponentPilot(PracticalComponentTemplate activeTemplate, ICollection<SelectedAssessmentTask> selectedAssessmentTasks)
        {
            PracticalComponentTemplatePilot = (PracticalComponentTemplatePilot)activeTemplate;
            SelectedAssessmentTasks = selectedAssessmentTasks;
        }

        // TODO - Implement IsCompetent
        public bool IsCompetent
        {
            get
            {
                return SelectedAssessmentTasks.Sum(s => s.Score) >= (SelectedAssessmentTasks.Sum(s => s.MaxScore) / 2.0);
            }
        }

        public IEnumerable<ISelectedAssessmentTask> AssessmentTasks
        {
            get { return SelectedAssessmentTasks; }
        }
    }
}
