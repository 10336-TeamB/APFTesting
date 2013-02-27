using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Managers
{
	class TheoryQuestionManager : Manager
	{
        public IEnumerable<Question> FetchRandomQuestions(int examTypeId)
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
            } while (randomQuestionList.Count < 10);

            //TODO: replace 10 with TheoryComponentFormat number of questions

            return randomQuestionList;

        }


        public List<Question> PackerQuestions
        {
            get
            {
                return _context.Questions.Where(q => q.ExamTypeId == 1).ToList();
            }
        }

        public List<Question> PilotQuestions
        {
            get
            {
                return _context.Questions.Where(q => q.ExamTypeId == 2).ToList();
            }
        }
	}
}
