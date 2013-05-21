using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class Create
    {
		#region Constructors

		public Create()
		{
			InitialiseCategories();
		}

		#endregion


		
		#region Properties

		public string ImagePath { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
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