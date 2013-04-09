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
            Score = task.Score.ToString();
            Title = task.Title;
            Details = task.Details;
            MaxScore = task.MaxScore;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int MaxScore { get; set; }
        
        public string Comment { get; set; }
        
        public string Score { get; set; }
    }
}
