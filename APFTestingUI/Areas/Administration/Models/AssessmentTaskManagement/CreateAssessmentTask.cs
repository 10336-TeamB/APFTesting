using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement
{
    public class CreateAssessmentTask
    {
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