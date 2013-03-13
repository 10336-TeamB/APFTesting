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
            Answers = question.PossibleAnswers.Select(a => new AnswerDisplayItem(a));
            NumberClass = determineClass(question.IsCorrect);
        }

        public int Index { get; set; }
        public string Description { get; set; }
        public IEnumerable<AnswerDisplayItem> Answers { get; set; }
        public string NumberClass { get; set; }

        private string determineClass(bool isCorrect)
        {
            return isCorrect ? "correct" : "incorrect";
        }
    }
}