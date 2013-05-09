using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement
{
    public class AssessmentTaskList
    {
        public IEnumerable<AssessmentTaskItem> AssessmentTasks { get; set; }
    }
}