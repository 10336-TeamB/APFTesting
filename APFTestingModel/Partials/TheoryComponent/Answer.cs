using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Answer : IAnswer
    {
		public Answer(AnswerDetails answerDetails, int displayOrderIndex, TheoryQuestion question)
		{
			Description = answerDetails.Description;
			IsCorrect = answerDetails.IsCorrect;
            DisplayOrderIndex = displayOrderIndex;
			TheoryQuestion = question;
			TheoryQuestionId = question.Id;
		}

        public void Edit(AnswerDetails answerDetails, int displayOrderIndex)
        {
            Description = answerDetails.Description;
            IsCorrect = answerDetails.IsCorrect;
            DisplayOrderIndex = displayOrderIndex;
        }

        public void Delete(deleteEntityDelegate<Answer> delete)
        {
            delete(this);
        }
    }
}
