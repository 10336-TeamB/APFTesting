using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PilotInput
    {
        public PilotInput() { }
        public PilotInput(Guid candidateId, IEnumerable<ISelectedAssessmentTask> tasks)
        {
            CandidateId = candidateId;
            Tasks = new List<AssessmentTaskDisplayItem>();
            foreach (var t in tasks)
            {
                Tasks.Add(new AssessmentTaskDisplayItem(t));
            }
        }

        public Guid CandidateId { get; set; }
        public List<AssessmentTaskDisplayItem> Tasks { get; set; }
    }
}