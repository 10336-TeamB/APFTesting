using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace APFTestingUI.Models.Candidate
{
    public class ViewPilot
    {
        public ViewPilot(ICandidatePilot candidate)
        {
            Id = candidate.Id;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            DateOfBirth = candidate.DateOfBirth;
            Address1 = candidate.Address.Address1;
            Address2 = candidate.Address.Address2;
            Suburb = candidate.Address.Suburb;
            State = candidate.Address.State;
            Postcode = candidate.Address.Postcode;
            ARN = candidate.ARN;
            Phone = candidate.PhoneNumber;
            Mobile = candidate.MobileNumber;
            Email = candidate.Email;
            PilotLicenceType = candidate.PilotLicenseType;
            InstrumentRating = candidate.InstrumentRating ? "Yes" : "No";
            PilotMedical = candidate.PilotMedicalType;
            PilotMedicalExpiry = candidate.PilotMedicalExpiryDate;
            ValidBFR = candidate.ValidBFR ? "Yes" : "No";
        }

        public Guid Id { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "D.O.B.")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string Suburb { get; set; }

        public string State { get; set; }

        public string Postcode { get; set; }

        public string ARN { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        [Display(Name = "Pilot licence type")]
        public PilotLicenseType PilotLicenceType { get; set; }
        
        [Display(Name = "Instrument rating")]
        public string InstrumentRating { get; set; }

        [Display(Name = "Pilot medical")]
        public PilotMedicalType PilotMedical { get; set; }

        [Display(Name = "Expiry date")]
        public DateTime PilotMedicalExpiry { get; set; }

        [Display(Name = "Valid BFR")]
        public string ValidBFR { get; set; }
    }
}
