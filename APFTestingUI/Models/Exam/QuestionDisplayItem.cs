using System.ComponentModel.DataAnnotations;
using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Answers = question.PossibleAnswers.Select(a => new AnswerDisplayItem(a));
            IsLastQuestion = question.IsLastQuestion;
            IsAnswered = question.IsAnswered;
            NavDirection = ExamAction.NextQuestion;
        }

        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        [Display(Name = "Review question later")]
        public bool IsMarkedForReview { get; set; }
        public IEnumerable<AnswerDisplayItem> Answers { get; set; }
        public bool IsLastQuestion { get; set; }
        public bool IsFirstQuestion
        {
            get { return Index == 0; }
        }
        public bool IsAnswered { get; set; }

        //Needed for question navigation direction and binding in cshtml, not assigned in this model (assigned by reflection in AnsweredQuestion)
        public ExamAction NavDirection { get; set; }
    }
}