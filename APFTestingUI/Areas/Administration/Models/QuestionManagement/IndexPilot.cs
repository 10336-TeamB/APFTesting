using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement
{
    public class IndexPilot
    {
        public IndexPilot(IEnumerable<ITheoryQuestion> theoryQuestions)
        {
            TheoryQuestions = theoryQuestions.Select(q => new TheoryQuestionItem(q)).ToList();
        }
        
        public IEnumerable<TheoryQuestionItem> TheoryQuestions { get; set; }
    }
}