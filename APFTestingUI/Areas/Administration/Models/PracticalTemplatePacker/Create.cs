using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.PracticalTemplatePacker
{
    public class Create
    {
        [Required]
        [Display(Name = "# of required demonstrated packs")]
        [Range(1, 30, ErrorMessage = "The number of required packs must be greater than 0 and not greater than 30")]
        public int NumOfRequiredAssessmentTasks { get; set; }
    }
}