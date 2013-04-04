using System.ComponentModel.DataAnnotations;
using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace APFTestingUI.Models.Practical
{
    public class AssessmentTaskDisplayItem
    {
        public AssessmentTaskDisplayItem() { }
        public AssessmentTaskDisplayItem(ISelectedAssessmentTask task)
        {
            Id = task.Id;
            Comment = task.Comment;
            Score = (task.Score == 0) ? "" : task.Score.ToString();
            Title = task.Title;
            Details = task.Details;
            MaxScore = task.MaxScore;
        }

        [HiddenInput(DisplayValue=false)]
        public Guid Id { get; set; }

        [HiddenInput(DisplayValue = true)]
        public string Title { get; set; }

        [HiddenInput(DisplayValue = true)]
        public string Details { get; set; }

        [HiddenInput(DisplayValue = true)]
        public int MaxScore { get; set; }
        
        [Required]
        public string Comment { get; set; }
        
        [Required]
        [RegularExpression("^([0-9][0-9]?|100)$", ErrorMessage="The Score must be between 0 and 100")]
        public string Score { get; set; }
    }
}
