using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class SelectedAssessmentTask : ISelectedAssessmentTask
    {
        public string Title
        {
            get { return AssessmentTaskPilot.Title; }
        }

        public string Details
        {
            get { return AssessmentTaskPilot.Details; }
        }

        public int MaxScore
        {
            get { return AssessmentTaskPilot.MaxScore; }
        }

        public void RecordResult(PilotPracticalResult result)
        {
            Comment = result.Comment;
            Score = result.Score;
        }
    }
}
