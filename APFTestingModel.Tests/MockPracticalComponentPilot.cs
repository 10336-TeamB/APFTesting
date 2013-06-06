using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    class MockPracticalComponentPilot : PracticalComponent
    {
       
        public bool IsCompetent
        {
            get { return true; }
        }

        public IEnumerable<ISelectedAssessmentTask> AssessmentTasks
        {
            get
            {
                yield return new SelectedAssessmentTask(new AssessmentTaskPilot());
                yield return new SelectedAssessmentTask(new AssessmentTaskPilot());
                yield return new SelectedAssessmentTask(new AssessmentTaskPilot());
                yield return new SelectedAssessmentTask(new AssessmentTaskPilot());
                yield return new SelectedAssessmentTask(new AssessmentTaskPilot());
            }
        }
    }
}
