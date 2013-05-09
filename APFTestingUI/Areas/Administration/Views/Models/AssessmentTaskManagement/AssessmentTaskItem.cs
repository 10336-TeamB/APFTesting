using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Editable = assessmentTask.EnableChange;
        }

        public Guid Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Max Score")]
        public int MaxScore { get; set; }
        public bool Editable { get; set; }
    }
}