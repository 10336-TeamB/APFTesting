using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.CompletedExam
{
    public class ExamDetailsPacker
    {
        public ExamDetailsPacker()
        {
        }

        public ExamDetailsPacker(ICandidatePacker candidate, IExam exam, ITheoryComponent theoryComponent, bool hasPassedPractical)
        {
            ExamId = exam.Id;
            APFNumber = candidate.APFNumber;
            Mobile = candidate.MobileNumber;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            TheoryScore = theoryComponent.Score;
            HasPassedTheory = theoryComponent.IsCompetent;
            HasPassedPractical = hasPassedPractical;
        }

        public Guid ExamId { get; set; }

        [Display(Name = "APF Number")]
        public string APFNumber { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile No.")]
        public string Mobile { get; set; }

        [Display(Name = "Theory Score")]
        public float TheoryScore { get; set; }

        [Display(Name = "Passed Theory Exam")]
        public bool HasPassedTheory { get; set; }

        [Display(Name = "Passed Practical Exam")]
        public bool HasPassedPractical { get; set; }
    }
}