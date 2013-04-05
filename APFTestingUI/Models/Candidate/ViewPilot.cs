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
        //public ViewPilot(ICandidatePilot candidate)
        //{
        //    Id = candidate.Id;
        //    FirstName = candidate.FirstName;
        //    LastName = candidate.LastName;
        //    DateOfBirth = candidate.DateOfBirth;
        //    Address1 = candidate.Address1;
        //    Address2 = candidate.Address2;
        //    Suburb = candidate.Suburb;
        //    Postcode = candidate.Postcode;
        //    ARN = candidate.ARN;
        //    Phone = candidate.Phone;
        //    Mobile = candidate.Mobile;
        //    Email = candidate.Email;
        //    PilotLicenceType = candidate.PilotLicenceType;
        //    InstrumentRating = candidate.InstrumentRating;
        //    PilotMedical = candidate.PilotMedical;
        //    PilotMedicalExpiry = candidate.PilotMedicalExpiry;
        //    ValidBFR = candidate.ValidBFR;
        //}

        public Guid Id { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "D.O.B.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string Suburb { get; set; }

        public string Postcode { get; set; }

        public string ARN { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        // TODO: Change this to Enum
        [Display(Name = "Pilot licence type")]
        public int PilotLicenceType { get; set; }
        
        [Display(Name = "Instrument rating")]
        public bool InstrumentRating { get; set; }

        // TODO: Change this to Enum
        [Display(Name = "Pilot medical")]
        public int PilotMedical { get; set; }

        [Display(Name = "Expiry date")]
        public DateTime PilotMedicalExpiry { get; set; }

        [Display(Name = "Valid BFR")]
        public bool ValidBFR { get; set; }
    }
}
