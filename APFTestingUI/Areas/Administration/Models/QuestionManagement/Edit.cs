using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class Edit
    {
        #region Constructors

        public Edit() { InitialiseCategories(); }

        public Edit(ITheoryQuestion question)
		{
            Id = question.Id;
            IsActive = question.IsActive;
            ImagePath = question.ImagePath;
            Description = question.Description;
            Category = question.Category;
            Answers = question.Answers.Select(a => new AnswerItem(a)).ToList();
            InitialiseCategories();
            EditableOrDeletable = question.EditableOrDeletable;
		}

		#endregion


		
		#region Properties

        [Required]
        public Guid Id { get; set; }
        
        public bool IsActive { get; set; }

        public string ImagePath { get; set; }
		
        [Required]
        [Display(Name = "Question Description")]
        public string Description { get; set; }
		
        [Required]
        public TheoryQuestionCategory Category { get; set; }
		public SelectList Categories { get; set; }
		
        public List<AnswerItem> Answers { get; set; }
        
        public bool EditableOrDeletable { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Delete Image")]
        public bool DeleteImage { get; set; }

		#endregion



		#region Methods

		public void InitialiseCategories()
		{
			var categories = Enum.GetValues(typeof(TheoryQuestionCategory));
			Categories = new SelectList(categories);
		}

		#endregion
    }
}