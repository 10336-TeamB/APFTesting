using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace APFTestingUI.Models.Candidate
{
    public class CreatePacker
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^04[0-9]{8}$", ErrorMessage = "Mobile number must be in the format 0400123123")]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "APF Number")]
        [RegularExpression(@"^[0-9]{5,6}$", ErrorMessage = "APF Number must be 5 or 6 digits")]
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
