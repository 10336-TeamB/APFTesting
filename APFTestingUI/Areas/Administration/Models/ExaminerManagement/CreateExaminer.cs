using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.ExaminerManagement
{
    public class CreateExaminer
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "APF Number")]
        [RegularExpression(@"^[0-9]{5,6}$")]
        public string APFNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength=7, ErrorMessage="The password length must be between 5 and 50 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Confirm your Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Examiner Pilot")]
        public bool ExaminerPacker { get; set; }

        [Display(Name = "Examiner Packer")]
        public bool ExaminerPilot { get; set; }
    }
}