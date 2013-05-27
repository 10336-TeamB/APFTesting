using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class TheoryQuestionItem
    {
        public TheoryQuestionItem(ITheoryQuestion question)
        {
            Id = question.Id;
            NumberOfCorrectAnswers = question.NumberOfCorrectAnswers;
            IsActive = question.IsActive;
			ImagePath = question.ImagePath;
			Description = question.Description;
			Category = question.Category;
            Answers = question.Answers.Select(a => new AnswerItem(a)).ToList();
            EditableOrDeletable = question.EditableOrDeletable;
        }

        public Guid Id { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public bool IsActive { get; set; }
		public string ImagePath { get; set; }
		public string Description { get; set; }
		public TheoryQuestionCategory Category { get; set; }
		public IEnumerable<AnswerItem> Answers { get; set; }
        public bool EditableOrDeletable { get; set; }
		
    }
}