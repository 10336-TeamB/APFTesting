using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.Exam
{
    public class TheoryComponentResult
    {
        public TheoryComponentResult(ITheoryComponentResult theoryComponentResult)
        {
            //IsCompetent = theoryComponentResult.IsCompetent;
            IsCompetent = false;
            //Score = theoryComponentResult.Score;
            Score = 12.09m;
        }
        
        //public Guid ExamId { get; set; }
        //public int Passmark { get; set; }
        public decimal Score { get; set; }
        public bool IsCompetent { get; set; }
    }
}