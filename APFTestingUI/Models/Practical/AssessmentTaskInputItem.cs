using System.ComponentModel.DataAnnotations;
using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace APFTestingUI.Models.Practical
{
    public class AssessmentTaskInputItem
    {
        public AssessmentTaskInputItem() { }
        public AssessmentTaskInputItem(ISelectedAssessmentTask task)
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
        
        public string Comment { get; set; }
        
        [Required(ErrorMessage="Please enter a positive whole number for the Score")]
        [DynamicRange("MaxScore", ErrorMessage="The Score must be a whole number between 0 and the specified maximum")]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "Please enter a positive whole number for the Score")]
        public string Score { get; set; }
    }
}
