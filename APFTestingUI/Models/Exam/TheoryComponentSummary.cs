using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.Exam
{
    public class TheoryComponentSummary
    {
        public Guid ExamId { get; set; }
        public IEnumerable<ISelectedTheoryQuestion> Questions { get; set; }
    }
}