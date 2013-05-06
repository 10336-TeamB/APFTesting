using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	internal partial class TheoryQuestion
	{
		public TheoryQuestion(TheoryQuestionDetails questionDetails)
		{
			Description = questionDetails.Description;
			constructAnswers(questionDetails.Answers);
			NumberOfCorrectAnswers = Answers.Count(a => a.IsCorrect == true);
			IsActive = questionDetails.IsActive;
			ImagePath = questionDetails.ImagePath;
			Category = questionDetails.Category;
		}

		private void constructAnswers(List<AnswerDetails> answers)
		{
			Answers = new List<Answer>();
			foreach (var answer in answers)
			{
				var newAnswer = new Answer(answer);
				Answers.Add(newAnswer);
			}
			
		}
	}
}
