using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PilotInput
    {
        public PilotInput(IEnumerable<ISelectedAssessmentTask> tasks)
        {
           Tasks = tasks.Select(t => new AssessmentTaskDisplayItem(t));
        }

        public IEnumerable<AssessmentTaskDisplayItem> Tasks { get; set; }
    }
}