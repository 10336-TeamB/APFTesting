using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Exam
{
    public class AnsweredQuestion
    {
        public Guid ExamId { get; set; }
        public int Index { get; set; }
        public int[] ChosenAnswer { get; set; }
        public bool IsMarkedForReview { get; set; }

        // Used in QuestionsController - Ajax method
        public ExamAction NavDirection { get; set; }

        // Used in ExamController - standard Action method
        // Used for form submission without JavaScript - NavButton assigned Value of submit button
        public string NavButton { get; set; }
        public ExamAction FormNavDirection
        {
            get
            {
                switch (NavButton)
                {
                    case "Next Question":
                        return ExamAction.NextQuestion;
                    case "Previous Question":
                        return ExamAction.PreviousQuestion;
                    default:
                        return ExamAction.DisplaySummary;
                }

            }
        }
    }
}