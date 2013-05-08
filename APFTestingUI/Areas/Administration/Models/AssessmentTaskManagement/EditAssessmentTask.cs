using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement
{
    public class EditAssessmentTask
    {
        public EditAssessmentTask()
        {
        }

        public EditAssessmentTask(IAssessmentTaskPilot assessmentTask)
        {
            Id = assessmentTask.Id;
            Title = assessmentTask.Title;
            Details = assessmentTask.Details;
            MaxScore = assessmentTask.MaxScore;
        }

        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Details")]
        [Required]
        public string Details { get; set; }

        [Display(Name = "Max Score")]
        [Required]
        [Range(1, Int32.MaxValue)]
        public int MaxScore { get; set; }

        public AssessmentTaskPilotDetails AssessmentTaskDetails { 
            get
            {
                return new AssessmentTaskPilotDetails
                {
                    Title = this.Title,
                    Details = this.Details,
                    MaxScore = this.MaxScore
                };
            }
        }
    }
}