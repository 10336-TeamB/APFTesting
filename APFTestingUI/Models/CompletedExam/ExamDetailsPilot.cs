using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.CompletedExam
{
    public class ExamDetailsPilot
    {
        public ExamDetailsPilot()
        {
        }

        public ExamDetailsPilot(ICandidatePilot candidate, IExam exam, ITheoryComponent theoryComponent, bool hasPassedPractical)
        {
            ExamId = exam.Id;
            ARN = candidate.ARN;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            DOB = candidate.DateOfBirth;
            Email = candidate.Email;
            Address = candidate.Address;
            Mobile = candidate.MobileNumber;
            Phone = candidate.PhoneNumber;
            LicenseType = candidate.PilotLicenceType;
            MedicalExpiryDate = candidate.PilotMedicalExpiryDate;
            PilotMedical = candidate.PilotMedicalType;
            HasValidBRF = candidate.ValidBFR;
            HasInstrumentRating = candidate.InstrumentRating;
            TheoryScore = theoryComponent.Score;
            HasPassedTheory = theoryComponent.IsCompetent;
            HasPassedPractical = hasPassedPractical;
        }

        public Guid ExamId { get; set; }

        [Display(Name = "ARN")]
        public string ARN { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public IAddress Address { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Mobile No.")]
        public string Mobile { get; set; }

        [Display(Name = "Phone No.")]
        public string Phone { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Pilot Licence Type")]
        public PilotLicenceType LicenseType { get; set; }

        [Display(Name = "Pilot Medical")]
        public PilotMedicalType PilotMedical { get; set; }

        [Display(Name = "Medical Expiry Date")]
        public DateTime MedicalExpiryDate { get; set; }

        [Display(Name = "Instrument Rating")]
        public bool HasInstrumentRating { get; set; }

        [Display(Name = "Valid BRF")]
        public bool HasValidBRF { get; set; }

        [Display(Name = "Theory Score")]
        public float TheoryScore { get; set; }

        [Display(Name = "Passed Theory Exam")]
        public bool HasPassedTheory { get; set; }

        [Display(Name = "Passed Practical Exam")]
        public bool HasPassedPractical { get; set; }

    }
}