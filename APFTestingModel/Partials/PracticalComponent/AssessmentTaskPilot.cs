using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class AssessmentTaskPilot : IAssessmentTaskPilot
    {
        public AssessmentTaskPilot(string title, string details, int maxScore)
        {
            Title = title;
            Details = details;
            MaxScore = maxScore;
        }
    }
}
