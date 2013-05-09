using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Models.TheoryFormat
{
    public class Edit
    {
        public Edit() { }

        public Edit(ITheoryComponentFormat format)
        {
            Id = format.Id;
            NumberOfQuestions = format.NumberOfQuestions;
            PassMark = format.PassMark;
            TimeLimit = format.TimeLimit;
        }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "An exam must have at least 1 question")]
        [Display(Name = "Number of questions")]
        public int NumberOfQuestions { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Pass mark must be greater than 0")]
        [Display(Name = "Pass mark")]
        public int PassMark { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Time limit must be between 0 and 120")]
        [Display(Name = "Time limit")]
        public int TimeLimit { get; set; }
    }
}