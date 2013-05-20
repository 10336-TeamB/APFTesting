using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;

namespace APFTestingUI.Areas.Administration.Models.QuestionManagement
{
	public class IndexPacker
	{
		public IndexPacker(IEnumerable<ITheoryQuestion> theoryQuestions)
        {
            TheoryQuestions = theoryQuestions.Select(q => new TheoryQuestionItem(q)).ToList();
        }
        
        public List<TheoryQuestionItem> TheoryQuestions { get; set; }
	}
}