﻿using System;
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
            Score = theoryComponentResult.Score.ToString("P0");
			Questions = theoryComponentResult.SelectedTheoryQuestions.Select(q => new ResultQuestionDisplayItem(q, examId)).ToList();
            Message = IsCompetent ? "Congratulations! You have passed" : "Unfortunately you did not pass";
        }
        
        public string Score { get; set; }
        public bool IsCompetent { get; set; }
        public IEnumerable<ResultQuestionDisplayItem> Questions { get; set; }
        public string Message { get; set; }
    }
}