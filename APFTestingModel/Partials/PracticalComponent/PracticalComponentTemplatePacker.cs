using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class PracticalComponentTemplatePacker : IPracticalComponentTemplatePacker
    {
        public PracticalComponentTemplatePacker(int numOfRequiredAssessmentTasks)
        {
            NumOfRequiredAssessmentTasks = numOfRequiredAssessmentTasks;
        }

        public bool AllowEditOrDelete
        {
            get { return PracticalComponentPackers.Count == 0 && !IsActive;  }
        }
    }
}
