using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.Exam
{
    public class TheoryComponentResult
    {
        public TheoryComponentResult(ITheoryComponent theoryComponentResult)
        {
            //IsCompetent = theoryComponentResult.IsCompetent;
            IsCompetent = false;
            //Score = theoryComponentResult.Score;
            Score = 12.09m;
			Questions = theoryComponentResult.SelectedTheoryQuestions;
        }
        
        //public Guid ExamId { get; set; }
        //public int Passmark { get; set; }
        public decimal Score { get; set; }
        public bool IsCompetent { get; set; }
		private IEnumerable<ISelectedTheoryQuestion> questions;
		public IEnumerable<ISelectedTheoryQuestion> Questions { 
			get
			{
				return questions.OrderBy(q => q.QuestionIndex); 
			}

			set
			{
				questions = value;
			}
		}
		
    }
}