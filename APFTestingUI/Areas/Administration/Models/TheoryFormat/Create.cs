using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Models.TheoryFormat
{
    public class Create
    {
        public Create()
        {
            BuildExamTypeSelectList();
        }

        [Required]
        [Range(1, 100, ErrorMessage = "An exam must have between 1 - 100 questions")]
        [Display(Name = "Number of questions")]
        public int NumberOfQuestions { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Pass mark must be greater than 0 and not more than 100")]
        [Display(Name = "Pass mark")]
        public int PassMark { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Time limit must be greater than 0 and not more than 120")]
        [Display(Name = "Time limit")]
        public int TimeLimit { get; set; }

        [Required]
        [Display(Name = "Exam type")]
        public ExamType ExamType { get; set; }
        public SelectList ExamTypes { get; set; }

        private void BuildExamTypeSelectList()
        {
            var values = Enum.GetValues(typeof(APFTestingModel.ExamType));
            ExamTypes = new SelectList(values);
        }
    }
}