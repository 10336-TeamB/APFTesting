using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class AnswerItem
    {
		public AnswerItem() { }
		
		public AnswerItem(IAnswer answer)
        {
            Id = answer.Id;
            Description = answer.Description;
            IsCorrect = answer.IsCorrect;
        }
        
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        public bool IsCorrect { get; set; }
    }
}