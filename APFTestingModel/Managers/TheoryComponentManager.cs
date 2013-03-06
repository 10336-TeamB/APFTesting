using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	abstract internal class TheoryComponentManager
	{
        IEnumerable<TheoryQuestion> theoryQuestions;

        public TheoryComponentManager(IEnumerable<TheoryQuestion> theoryQuestions)
        {
            this.theoryQuestions = theoryQuestions;
        }

        public ICollection<TheoryQuestion> FetchRandomQuestions(int examTypeId, int numOfQuestions)
        {
            var questionList = theoryQuestions.ToList();
            List<TheoryQuestion> randomQuestionList = new List<TheoryQuestion>();
            Random random = new Random();
            do
            {
                int randomIndex = random.Next(0, questionList.Count);
                var randomQuestion = questionList[randomIndex];
                randomQuestionList.Add(randomQuestion);
                questionList.Remove(randomQuestion);
            } while (randomQuestionList.Count < numOfQuestions);
            return randomQuestionList;
        }

		// Commented out to allow compilation
        //public TheoryComponentFormat FetchActiveExamFormat(int examTypeId)
        //{
        //    var activeExamFormat = _context.TheoryComponentFormats.First(format => format.ExamTypeId == examTypeId);
        //    return activeExamFormat;
        //}

        //public TheoryComponent CreateTheoryComponent(int examTypeId, Examiner examiner)
        //{
        //    TheoryComponentFormat format = FetchActiveExamFormat(examTypeId);
        //    TheoryComponent _theoryComponent = new TheoryComponent(format, examiner, FetchRandomQuestions(examTypeId, format.NumberOfQuestions));
        //    return _theoryComponent;
        //}
	}
}
