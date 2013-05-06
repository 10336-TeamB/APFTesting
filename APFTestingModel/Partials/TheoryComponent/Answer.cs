using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Answer : IAnswer
    {
		public Answer(AnswerDetails answerDetails)
		{
			Description = answerDetails.Description;
			IsCorrect = answerDetails.IsCorrect;
			DisplayOrderIndex = answerDetails.DisplayOrderIndex;
		}
    }
}
