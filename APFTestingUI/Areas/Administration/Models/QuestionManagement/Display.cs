using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class Display
    {
        #region Constructors

        public Display() { }

        public Display(ITheoryQuestion question)
		{
            Id = question.Id;
            ImagePath = question.ImagePath;
            Description = question.Description;
            Category = question.Category;
            Answers = question.Answers.Select(a => new AnswerItem(a)).ToList();
            EditableOrDeletable = question.EditableOrDeletable;

		}

		#endregion
        
        #region Properties

        public Guid Id { get; private set; }

        public string ImagePath { get; private set; }

        public string Description { get; private set; }

        public TheoryQuestionCategory Category { get; private set; }

        public List<AnswerItem> Answers { get; private set; }

        public bool EditableOrDeletable { get; set; }
        
        #endregion


    }
}