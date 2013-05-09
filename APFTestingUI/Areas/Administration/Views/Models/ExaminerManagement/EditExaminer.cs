using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.ExaminerManagement
{
    public class EditExaminer
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "APF Number")]
        public string APFNumber { get; set; }

        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }
        
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Display(Name = "Examiner Pilot")]
        public bool ExaminerPacker { get; set; }

        [Display(Name = "Examiner Packer")]
        public bool ExaminerPilot { get; set; }

        public EditExaminer() { }

        public EditExaminer(IExaminer examiner)
        {
            FirstName = examiner.FirstName;
            LastName = examiner.LastName;
            APFNumber = examiner.APFNumber;
            ExaminerPacker = examiner.ExaminerAuthorities.Any(a => a.ExamType == ExamType.PackerExam);
            ExaminerPilot = examiner.ExaminerAuthorities.Any(a => a.ExamType == ExamType.PilotExam);
        }
    }
}