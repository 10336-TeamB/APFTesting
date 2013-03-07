using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class QuestionDisplayItem
    {
        public QuestionDisplayItem(ISelectedTheoryQuestion question)
        {
            Id = question.Id;
            Index = question.QuestionIndex;
            //Description = question.Description;
            IsMarkedForReview = question.IsMarkedForReview;
            //Answers = question.SelectedAnswers;


        }

        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public bool IsMarkedForReview { get; set; }
        public IEnumerable<IPossibleAnswer> Answers { get; set; }
        public int[] SelectedAnswers { get; set; }
    }
}