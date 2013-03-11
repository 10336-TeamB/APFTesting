using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class QuestionDisplayItem
    {
        public QuestionDisplayItem(ISelectedTheoryQuestion question, Guid examId)
        {
            Id = question.Id;
            ExamId = examId;
            Index = question.QuestionIndex;
            Description = question.Description;
            NumberOfCorrectAnswers = question.NumberOfCorrectAnswers;
            IsMarkedForReview = question.IsMarkedForReview;
            //Answers = createMockAnswers();
            Answers = question.ISelectedAnswers.Select(a => new AnswerDisplayItem(a));
            IsLastQuestion = question.IsLastQuestion;
        }

        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public bool IsMarkedForReview { get; set; }
        public IEnumerable<AnswerDisplayItem> Answers { get; set; }
        public bool IsLastQuestion { get; set; }
        public bool IsFirstQuestion
        {
            get { return Index == 0; }
        }

        //Needed for question navigation direction and binding in cshtml, not assigned directly in this model
        public bool NavDirection { get; set; }
    }
}