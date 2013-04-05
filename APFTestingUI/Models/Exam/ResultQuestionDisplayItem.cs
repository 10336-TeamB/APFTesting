using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class ResultQuestionDisplayItem
    {
        public ResultQuestionDisplayItem(ISelectedTheoryQuestion question, Guid examId)
        {
            Index = question.QuestionIndex;
            Description = question.Description;
            Answers = question.PossibleAnswers.Select(a => new ResultAnswerDisplayItem(a)).ToList();
            NumberClass = question.IsCorrect ? "correct" : "incorrect";
            IsMarkedClass = question.IsMarkedForReview ? " marked" : "";
            IsAnsweredClass = question.IsAnswered ? "" : " not-answered";
        }

        

        public int Index { get; set; }
        public string Description { get; set; }
        public IEnumerable<ResultAnswerDisplayItem> Answers { get; set; }
        public string NumberClass { get; set; }
        public string IsMarkedClass { get; set; }
        public string IsAnsweredClass { get; set; }
    }
}