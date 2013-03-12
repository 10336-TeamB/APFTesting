using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.Exam
{
    public class TheoryComponentResult
    {
        public TheoryComponentResult(Guid examId, ITheoryComponent theoryComponentResult)
        {
            IsCompetent = theoryComponentResult.IsCompetent;
            Score = theoryComponentResult.Score.ToString("###.##") + "%";
            //TODO - Should QuestionDisplayItem require ExamId?
			Questions = theoryComponentResult.SelectedTheoryQuestions.Select(q => new QuestionDisplayItem(q, examId));
            Message = IsCompetent ? "Congratulations! You have passed" : "Unfortunately you did not pass";
        }
        
        public string Score { get; set; }
        public bool IsCompetent { get; set; }
        public IEnumerable<QuestionDisplayItem> Questions { get; set; }
        public string Message { get; set; }
    }
}