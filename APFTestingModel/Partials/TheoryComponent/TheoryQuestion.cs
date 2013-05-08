using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal abstract partial class TheoryQuestion : ITheoryQuestion
    {
        #region Constructors

        public TheoryQuestion(List<Answer> answers)
        {
            Answers = answers;
        }

		public TheoryQuestion(TheoryQuestionDetails questionDetails)
		{
			Description = questionDetails.Description;
			constructAnswers(questionDetails.Answers);
			NumberOfCorrectAnswers = Answers.Count(a => a.IsCorrect == true);
			IsActive = true;
			ImagePath = questionDetails.ImagePath;
			Category = questionDetails.Category;
		}

        #endregion



		private void constructAnswers(List<AnswerDetails> answers)
		{
			Answers = new List<Answer>();
			foreach (var answer in answers)
			{
				var newAnswer = new Answer(answer);
				Answers.Add(newAnswer);
			}

		}

        IEnumerable<IAnswer> ITheoryQuestion.Answers
        {
            get { return Answers; }
        }
    }
}
