using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class AssessmentTaskPilot : IAssessmentTaskPilot
    {
        public AssessmentTaskPilot(AssessmentTaskPilotDetails details)
        {
            Title = details.Title;
            Details = details.Details;
            MaxScore = details.MaxScore;
        }

        public void Edit(AssessmentTaskPilotDetails details)
        {
            if (!EnableChange)
            {
                throw new Exception("Assessment task is used by one or more templates. It cannot be modified.");
            }
            Title = details.Title;
            Details = details.Details;
            MaxScore = details.MaxScore;
        }

        public bool EnableChange
        {
            get { return !this.SelectedAssessmentTasks.Any(); }
        }

        internal void Delete(deleteEntityDelegate<AssessmentTaskPilot> delete)
        {
            if (!EnableChange)
            {
                throw new Exception("Assessment task is used by one or more templates. It cannot be modified.");
            }
            delete(this);
        }
    }
}
