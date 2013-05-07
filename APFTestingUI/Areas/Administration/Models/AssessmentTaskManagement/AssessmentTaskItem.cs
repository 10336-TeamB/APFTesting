using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement
{
    public class AssessmentTaskItem
    {
        public AssessmentTaskItem(IAssessmentTaskPilot assessmentTask)
        {
            Id = assessmentTask.Id;
            Title = assessmentTask.Title;
            Details = assessmentTask.Details;
            MaxScore = assessmentTask.MaxScore;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int MaxScore { get; set; }
    }
}