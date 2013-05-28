using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace APFTestingUI.Models.Candidate
{
    public class EditPacker
    {
        public EditPacker() { }

        public EditPacker(ICandidatePacker candidate)
        {
            Id = candidate.Id;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            Mobile = candidate.MobileNumber;
            APFNumber = candidate.APFNumber;
        }
        
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^04[0-9]{8}$")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "APF Number")]
        [RegularExpression(@"^[0-9]{5,6}$")]
        public string APFNumber { get; set; }

        // To return all values to the model using a struct
        public CandidatePackerDetails Values
        {
            get
            {
                return new CandidatePackerDetails
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    Mobile = this.Mobile,
                    APFNumber = this.APFNumber
                };
            }
        }
    }
}
