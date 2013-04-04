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
            List<SelectedAssessmentTask> selectedAssessmentTasks = new List<SelectedAssessmentTask>();
            ICollection<AssessmentTaskPilot> assessmentTasks = (activeTemplate as PracticalComponentTemplatePilot).AssessmentTaskPilots;
            foreach (AssessmentTaskPilot a in assessmentTasks)
            {
                selectedAssessmentTasks.Add(new SelectedAssessmentTask(a));
            }

            PracticalComponentPilot practicalComponentPilot = new PracticalComponentPilot(activeTemplate, selectedAssessmentTasks);
            
            return practicalComponentPilot;
        }
    }
}
