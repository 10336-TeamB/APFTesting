using APFTestingModel;
using System;
using System.Collections.Generic;
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
        
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
    }
}