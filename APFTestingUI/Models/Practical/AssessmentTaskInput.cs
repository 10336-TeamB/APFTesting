using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Practical
{
    public class AssessmentTaskInput
    {
        public Guid[] Id { get; set; }
        public string[] Comment { get; set; }
        public int[] Score { get; set; }
    }
}