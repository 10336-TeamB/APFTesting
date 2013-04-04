using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class PilotView
    {
        public PilotView(Guid examId, Guid candidateId, IEnumerable<ISelectedAssessmentTask> tasks)
        {
            ExamId = examId;
            CandidateId = candidateId;
            Tasks = new List<AssessmentTaskDisplayItem>();
            TotalScore = 0;
            TotalMaxScore = 0;
            foreach (var t in tasks)
            {
                Tasks.Add(new AssessmentTaskDisplayItem(t));
                TotalScore += (int)t.Score;
                TotalMaxScore += t.MaxScore;
            }
        }

        public Guid ExamId { get; set; }
        public Guid CandidateId { get; set; }
        public List<AssessmentTaskDisplayItem> Tasks { get; set; }
        public int TotalScore { get; set; }
        public int TotalMaxScore { get; set; }
    }
}