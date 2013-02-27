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
            TheoryComponentFormat format = fetchActiveExamFormat(examTypeId);

            TheoryComponent _theoryComponent = new TheoryComponent(format, examiner, FetchRandomQuestions(examTypeId, format.NumberOfQuestions));
			

			return _theoryComponent;
		}


        public ICollection<Question> FetchRandomQuestions(int examTypeId, int questionTotal)
        {
            var questionList = _context.Questions.Where(question => question.ExamTypeId == examTypeId).ToList();
            List<Question> randomQuestionList = new List<Question>();

            Random random = new Random();
            do
            {
                int randomIndex = random.Next(0, questionList.Count);
                var randomQuestion = questionList[randomIndex];
                randomQuestionList.Add(randomQuestion);
                questionList.Remove(randomQuestion);
            } while (randomQuestionList.Count < questionTotal);

            //TODO: replace 10 with TheoryComponentFormat number of questions

            return randomQuestionList;

        }

        // TODO: Commented out as EmaxType does not exist preventing compilation - ADAM
        //public ICollection<Question> SelectRandomQuestions(ExamType examType)
        //{
        //    List<Question> questions = (examType == ExamType.PACKER_EXAM) ? questions = _theoryQuestionManager.PackerQuestions : questions = _theoryQuestionManager.PilotQuestions;
        //    List<Question> randomQuestions = new List<Question>();
            
        //    Random random = new Random();

        //    for (int i = 0; i < exam.TheoryComponentFormat.NumberOfQuestions; ++i)
        //    {
        //        int randIndex = random.Next() % questions.Count;
        //        exam.AddTheoryQuestion(questions.ElementAt(randIndex));
        //        questions.RemoveAt(randIndex);
        //    }
        //}

	}
}
