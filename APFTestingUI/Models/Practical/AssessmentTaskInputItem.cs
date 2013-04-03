using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class AssessmentTaskInputItem
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
    }
}