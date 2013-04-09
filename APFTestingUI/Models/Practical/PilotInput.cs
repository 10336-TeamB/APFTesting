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
        public PilotInput(Guid examId, Guid candidateId, IEnumerable<ISelectedAssessmentTask> tasks)
        {
            ExamId = examId;
            CandidateId = candidateId;
            Tasks = new List<AssessmentTaskInputItem>();
            foreach (var t in tasks)
            {
                Tasks.Add(new AssessmentTaskInputItem(t));
            }
        }

        public Guid ExamId { get; set; }
        public Guid CandidateId { get; set; }
        public List<AssessmentTaskInputItem> Tasks { get; set; }
    }
}