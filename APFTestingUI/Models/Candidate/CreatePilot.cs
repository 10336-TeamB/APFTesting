using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace APFTestingUI.Models.Candidate
{
    public class CreatePilot
    {
        public CreatePilot() {
            BuildPilotLicenceSelectList();
            BuildStateSelectList();
        }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "D.O.B.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string State { get; set; }
        public SelectList States { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Postcode must have 4 digits")]
        public string Postcode { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "ARN must a 6-digit number")]
        public string ARN { get; set; }

        [RegularExpression(@"^04[0-9]{8,10}$", ErrorMessage = "Phone number must have between 8-10 digits")]
        public string Phone { get; set; }

        [RegularExpression(@"^04[0-9]{8}$", ErrorMessage = "Mobile number must be in the format 0400123123")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        [Display(Name = "Pilot licence type")]
        public PilotLicenceType PilotLicenceType { get; set; }
        public SelectList PilotLicences { get; private set; }
        
        [Required]
        [Display(Name = "Instrument rating")]
        public bool InstrumentRating { get; set; }

        
        [Required]
        [Display(Name = "Pilot medical")]
        public PilotMedicalType PilotMedical { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry date")]
        public DateTime PilotMedicalExpiry { get; set; }

        [Required]
        [Display(Name = "Valid BFR")]
        [BooleanMustBeTrue(ErrorMessage = "Pilot must have a valid BFR")]
        public bool ValidBFR { get; set; }


        // To return all values to the model using a struct
        public CandidatePilotDetails Values
        {
            get
            {
                return new CandidatePilotDetails
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    DateOfBirth = this.DateOfBirth,
                    Address1 = this.Address1,
                    Address2 = this.Address2,
                    Suburb = this.Suburb,
                    State = this.State,
                    Postcode = this.Postcode,
                    ARN = this.ARN,
                    Phone = this.Phone,
                    Mobile = this.Mobile,
                    Email = this.Email,
                    PilotLicenceType = this.PilotLicenceType,
                    InstrumentRating = this.InstrumentRating,
                    PilotMedical = this.PilotMedical,
                    PilotMedicalExpiry = this.PilotMedicalExpiry,
                    ValidBFR = this.ValidBFR
                };
            }
        }

        public void BuildPilotLicenceSelectList()
        {
            var values = Enum.GetValues(typeof(APFTestingModel.PilotLicenceType));
            PilotLicences = new SelectList(values);
        }

        public void BuildStateSelectList()
        {
            string[] states = new string[]{"ACT", "NSW", "SA", "QLD", "VIC", "TAS", "WA"};
            States = new SelectList(states);
        }
    }
}
