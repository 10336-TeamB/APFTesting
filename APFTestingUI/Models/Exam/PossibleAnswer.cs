using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam {
    public class PossibleAnswer {
        public PossibleAnswer()
        {
        }

        public PossibleAnswer(ISelectedAnswer possibleAnswer)
        {
            Description = possibleAnswer.Description;
            DisplayOrderIndex = possibleAnswer.DisplayOrderIndex;
        }

        public string Description { get; set; }
        public int DisplayOrderIndex { get; set; }
    }
}