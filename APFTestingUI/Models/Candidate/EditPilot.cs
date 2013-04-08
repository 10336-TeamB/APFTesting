using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace APFTestingUI.Models.Candidate
{
    public class EditPilot
    {
        private const int _arnLength = 6;
        private const int _phoneLength = 10;
        private const int _mobileLength = 10;
        private const int _postcodeLength = 4;

        public EditPilot() { }

        public EditPilot(ICandidatePilot candidate)
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
            InstrumentRating = candidate.InstrumentRating;
            PilotMedical = candidate.PilotMedicalType;
            PilotMedicalExpiry = candidate.PilotMedicalExpiryDate;
            ValidBFR = candidate.ValidBFR;
            BuildPilotLicenceSelectList();
        }

        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string State { get; set; }

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
        public short? PilotLicenceType { get; set; }
        public SelectList PilotLicences { get; private set; }

        [Required]
        public bool InstrumentRating { get; set; }

        // TODO: Change this to Enum
        [Required]
        public short? PilotMedical { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PilotMedicalExpiry { get; set; }

        [Required]
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
                    DateOfBirth = DateTime.Parse(this.DateOfBirth.ToString()), // TODO: Update once field no longer nullable
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

        public void BuildPilotLicenceSelectList()
        {
            var list = new Dictionary<string, int>();
            var values = Enum.GetValues(typeof(APFTestingModel.PilotLicenseType));

            for (var i = 0; i < values.Length; i++)
            {
                var value = values.GetValue(i);
                list.Add(value.ToString(), (short)value);
            }

            PilotLicences = new SelectList(list, "Value", "Key");
        }
    }
}
