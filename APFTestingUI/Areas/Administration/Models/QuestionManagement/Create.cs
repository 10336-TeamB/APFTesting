using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class Create
    {
        public Create(ITheoryQuestion question)
        {
            Id = question.Id;
            NumberOfCorrectAnswers = question.NumberOfCorrectAnswers;
            IsActive = question.IsActive;
            Description = question.Description;
            ImagePath = question.ImagePath;
            Answers = question.Answers.Select(a => new AnswerItem(a)).ToList();
        }

        public Guid Id { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<AnswerItem> Answers { get; set; }
    }
}