﻿using APFTestingModel;
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
            BuiltPilotLicenceSelectList();
        }

        private const int _arnLength = 6;
        private const int _phoneLength = 10;
        private const int _mobileLength = 10;
        private const int _postcodeLength = 4;

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
        [StringLength(_postcodeLength, MinimumLength = _postcodeLength)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(_arnLength, MinimumLength=_arnLength)]
        public string ARN { get; set; }

        [StringLength(_phoneLength, MinimumLength = _phoneLength)]
        public string Phone { get; set; }

        [StringLength(_mobileLength, MinimumLength = _mobileLength)]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // TODO: Change this to Enum
        [Required]
        [Display(Name = "Pilot licence type")]
        public int PilotLicenceType { get; set; }
        public SelectList PilotLicences { get; private set; }
        
        [Required]
        [Display(Name = "Instrument rating")]
        public bool InstrumentRating { get; set; }

        // TODO: Change this to Enum
        [Required]
        [Display(Name = "Pilot medical")]
        public int PilotMedical { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry date")]
        public DateTime PilotMedicalExpiry { get; set; }

        [Required]
        [Display(Name = "Valid BFR")]
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

        public void BuiltPilotLicenceSelectList()
        {
            var list = new Dictionary<string, int>();
            list.Add("PPL", 1);
            list.Add("CPL", 2);
            list.Add("ATPL", 3);

            PilotLicences = new SelectList(list, "Value", "Key");
        }
    }
}