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
        public int NumOfRequiredAssessmentTasks { get; set; }
    }
}