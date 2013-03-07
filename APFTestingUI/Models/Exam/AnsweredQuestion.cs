using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class AnsweredQuestion
    {
        public Guid ExamId { get; set; }
        public int Index { get; set; }
        public int[] ChosenAnswer { get; set; }
        public bool NavDirection { get; set; }
    }
}