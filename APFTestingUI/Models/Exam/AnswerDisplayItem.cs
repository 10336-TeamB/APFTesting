using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class AnswerDisplayItem
    {
        public AnswerDisplayItem() { }
        public AnswerDisplayItem(IPossibleAnswer answer)
        {
            DisplayOrderIndex = answer.DisplayOrderIndex;
            Description = answer.Description;
            IsChecked = answer.IsChecked;
            IsCorrect = answer.IsCorrect;
        }
        public int DisplayOrderIndex { get; set; }
        public string Description { get; set; }
        public bool IsChecked { get; set; }
        public bool IsCorrect { get; set; }
    }
}