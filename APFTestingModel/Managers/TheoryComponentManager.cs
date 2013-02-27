using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Managers
{
	class TheoryComponentManager : Manager
	{
		private TheoryQuestionManager _theoryQuestionManager = new TheoryQuestionManager();

		public TheoryComponentFormat fetchActiveExamFormat(int examTypeId)
		{
			var activeExamFormat = _context.TheoryComponentFormats.First(format => format.ExamTypeId == examTypeId);

			return activeExamFormat;
		}

		public TheoryComponent CreateTheoryComponent(int examTypeId, Examiner examiner)
		{

			TheoryComponent _theoryComponent = new TheoryComponent(fetchActiveExamFormat(examTypeId), 
																	examiner, 
																	_theoryQuestionManager.FetchRandomQuestions(examTypeId));
			

			return _theoryComponent;
		}

		

	}
}
