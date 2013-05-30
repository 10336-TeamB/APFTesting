using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
	abstract internal class TheoryComponentManager
	{

        protected TheoryComponentFormat activeFormat;

        private IEnumerable<TheoryQuestion> theoryQuestions;

        public abstract TheoryComponent GenerateTheoryComponent();

	    public abstract TheoryComponentFormat CreateTheoryExamFormat(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions);

        protected void validateExamFormatDetails(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions)
        {
            if (numberOfQuestions <= 0) 
            {
                throw new BusinessRuleException("Theory exam format must have at least one question.");
            }
            if (numberOfQuestions > availableQuestions)
            {
                throw new BusinessRuleException(String.Format("Can not create a format with {0} questions. Only {1} questions are available", numberOfQuestions, availableQuestions));
            }
            if (passMark <= 0 || passMark > 100) 
            {
                throw new BusinessRuleException("Pass mark must be between 0 and 100.");
            }
            if (timeLimit < 0 || timeLimit > 120) 
            {
                throw new BusinessRuleException("Time limit must be between 0 and 120 minutes.");
            }
        }

        public TheoryComponentManager() { }

        public TheoryComponentManager(IEnumerable<TheoryQuestion> theoryQuestions, TheoryComponentFormat activeFormat)
        {
            this.theoryQuestions = theoryQuestions;
            this.activeFormat = activeFormat;
        }

        public ICollection<SelectedTheoryQuestion> FetchRandomQuestions(int numOfQuestions, TheoryComponent theoryComponent)
        {
            var questionList = theoryQuestions.ToList();
            questionList = questionList.Where(q => q.IsActive == true).ToList(); //Hope this works


            List<SelectedTheoryQuestion> randomQuestionList = new List<SelectedTheoryQuestion>();
            Random random = new Random();
            int questionIndex = 0;
            do
            {
                int randomIndex = random.Next(0, questionList.Count);
                var randomQuestion = questionList[randomIndex];
                randomQuestionList.Add(new SelectedTheoryQuestion(theoryComponent, randomQuestion, questionIndex));
                questionIndex++;
                questionList.Remove(randomQuestion);
            } while (randomQuestionList.Count < numOfQuestions);
            return randomQuestionList;
        }

		public abstract TheoryQuestion CreateTheoryQuestion(TheoryQuestionDetails questionDetails);
	}
}
