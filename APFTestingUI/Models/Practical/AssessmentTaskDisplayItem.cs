using System.ComponentModel.DataAnnotations;
using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingUI.Models.Practical
{
    public class AssessmentTaskDisplayItem
    {
        public AssessmentTaskDisplayItem(ISelectedAssessmentTask task)
        {
            Id = task.Id;
            Comment = task.Comment;
            Score = (int)task.Score;
            Title = task.Title;
            Details = task.Details;
            MaxScore = task.MaxScore;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int MaxScore { get; set; }
        
        [Required]
        public string Comment { get; set; }
        
        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
    }
}
