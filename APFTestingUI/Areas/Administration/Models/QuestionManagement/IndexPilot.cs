using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
    public class IndexPilot
    {
        public IndexPilot(IEnumerable<ITheoryQuestion> theoryQuestions)
        {
            TheoryQuestions = theoryQuestions.Select(q => new TheoryQuestionItem(q)).ToList();
        }
        
        public List<TheoryQuestionItem> TheoryQuestions { get; set; }
    }
}