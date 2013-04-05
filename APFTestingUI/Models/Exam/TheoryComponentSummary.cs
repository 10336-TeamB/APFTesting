using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Models.Exam
{
    public class TheoryComponentSummary
    {
        public TheoryComponentSummary(Guid examId, IEnumerable<ISelectedTheoryQuestion> questions)
        {
            ExamId = examId;
            Questions = questions.Select(q => new ResultQuestionDisplayItem(q, examId)).ToList();
        }

        public Guid ExamId { get; set; }
        public IEnumerable<ResultQuestionDisplayItem> Questions { get; set; }
    }
}