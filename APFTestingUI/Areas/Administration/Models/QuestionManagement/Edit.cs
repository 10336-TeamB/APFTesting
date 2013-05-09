using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class Edit
    {
        #region Constructors

        public Edit() { }

        public Edit(ITheoryQuestion question)
		{
            Id = question.Id;
            IsActive = question.IsActive;
            ImagePath = question.ImagePath;
            Description = question.Description;
            Category = question.Category;
            Answers = question.Answers.Select(a => new AnswerItem(a)).ToList();
            InitialiseCategories();
		}

		#endregion


		
		#region Properties

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
		public string ImagePath { get; set; }
		public string Description { get; set; }
		public TheoryQuestionCategory Category { get; set; }
		public SelectList Categories { get; set; }
		public List<AnswerItem> Answers { get; set; }

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