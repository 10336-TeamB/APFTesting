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
        [Range(1, 100, ErrorMessage = "An exam must have between 1 - 100 questions")]
        [Display(Name = "Number of questions")]
        public int NumberOfQuestions { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Pass mark must be an integer greater than 0 and not more than 100")]
        [Display(Name = "Pass mark")]
        public int PassMark { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Time limit must be an integer greater than 0 and not more than 120")]
        [Display(Name = "Time limit")]
        public int TimeLimit { get; set; }
    }
}