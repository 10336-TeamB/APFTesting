using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class SelectedAssessmentTask : ISelectedAssessmentTask
    {
        public SelectedAssessmentTask() { }

        public SelectedAssessmentTask(AssessmentTaskPilot assessmentTask)
        {
            this.AssessmentTaskPilot = assessmentTask;
        }

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




        Guid ISelectedAssessmentTask.Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string ISelectedAssessmentTask.Comment
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        int? ISelectedAssessmentTask.Score
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string ISelectedAssessmentTask.Title
        {
            get { throw new NotImplementedException(); }
        }

        string ISelectedAssessmentTask.Details
        {
            get { throw new NotImplementedException(); }
        }

        int ISelectedAssessmentTask.MaxScore
        {
            get { throw new NotImplementedException(); }
        }
    }
}
