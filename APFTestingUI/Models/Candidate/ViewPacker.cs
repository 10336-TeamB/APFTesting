using APFTestingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace APFTestingUI.Models.Candidate
{
    public class ViewPacker
    {
        public ViewPacker(ICandidatePacker candidate)
        {
            Id = candidate.Id;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            Mobile = candidate.MobileNumber;
            APFNumber = candidate.APFNumber;
        }

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Mobile { get; set; }

        [Display(Name = "APF Number")]
        public string APFNumber { get; set; }
    }
}
