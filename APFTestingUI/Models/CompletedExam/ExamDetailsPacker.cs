using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.CompletedExam
{
    public class ExamDetailsPacker
    {
        public ExamDetailsPacker(ICandidatePacker candidate, IExam exam)
        {
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}