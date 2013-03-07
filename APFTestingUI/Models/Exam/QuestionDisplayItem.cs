﻿using APFTestingModel;
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
            IsMarkedForReview = question.IsMarkedForReview;
            NumberOfCorrectAnswers = question.NumberOfCorrectAnswers;
            //Answers = question.PossibleAnswers.Select(a => new AnswerDisplayItem(a));
            Answers = createMockAnswers();
           
        }

        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public bool IsMarkedForReview { get; set; }
        public IEnumerable<AnswerDisplayItem> Answers { get; set; }

        //Needed for question navigation direction and binding in cshtml, not used in this model
        public bool NavDirection { get; set; }

        private IEnumerable<AnswerDisplayItem> createMockAnswers()
        {
            yield return new AnswerDisplayItem { Description = "First answer", DisplayOrderIndex = 1 };
            yield return new AnswerDisplayItem { Description = "Second answer", DisplayOrderIndex = 2 };
            yield return new AnswerDisplayItem { Description = "Third answer", DisplayOrderIndex = 3 };
            yield return new AnswerDisplayItem { Description = "Fourth answer", DisplayOrderIndex = 4 };
        }
    }
}