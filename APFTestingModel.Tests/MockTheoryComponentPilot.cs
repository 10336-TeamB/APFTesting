using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    class MockTheoryComponentPilot : ITheoryComponent
    {
         public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public Guid FormatId
        {
            get { return Guid.NewGuid(); }
        }

        public int CurrentQuestionIndex = 0;

        public DateTime Date
        {
            get { return DateTime.Now; }
        }

        public IEnumerable<ISelectedTheoryQuestion> SelectedTheoryQuestions
        {
            //Do not delete or add any questions or else something bad will happen tyo you!!!
            get {
                yield return new MockSelectedTheoryQuestion(0);
                yield return new MockSelectedTheoryQuestion(1);
                yield return new MockSelectedTheoryQuestion(2);
                yield return new MockSelectedTheoryQuestion(3);
                yield return new MockSelectedTheoryQuestion(4);
            }
        }

        public TheoryComponentFormat TheoryComponentFormat = new TheoryComponentFormatPilot(5, 80);

        public float Score
		{
			get
			{
				float numberOfCorrectAnswers = SelectedTheoryQuestions.Count(question => question.IsCorrect);
				return (numberOfCorrectAnswers / 5);
			}
		}

		public bool IsCompetent
		{
			get { return ((Score * 100.0) >= TheoryComponentFormat.PassMark); }
		}

        //IEnumerable<ISelectedTheoryQuestion> ITheoryComponent.SelectedTheoryQuestions
        //{
        //    get { return SelectedTheoryQuestions.OrderBy(q => q.QuestionIndex); }
        //}


		public ISelectedTheoryQuestion FetchFirstQuestion()
        {
            if (CurrentQuestionIndex == 0)
            {
                return SelectedTheoryQuestions.First(q => q.QuestionIndex == 0);
            }
            else
            {
                throw new BusinessRuleException("Not permitted to fetch first question when current question index is beyond first question");
            }
            
        }

		public ISelectedTheoryQuestion FetchNextQuestion()
		{
            if (CurrentQuestionIndex < 4)
            {
                ++CurrentQuestionIndex;
            }
            
            return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

		public ISelectedTheoryQuestion FetchPreviousQuestion()
		{
            if (CurrentQuestionIndex > 0)
            {
                --CurrentQuestionIndex;
            }

            return SelectedTheoryQuestions.First(question => question.QuestionIndex == CurrentQuestionIndex);
		}

        public ISelectedTheoryQuestion FetchCurrentQuestion()
        {
            return SelectedTheoryQuestions.First(q => q.QuestionIndex == CurrentQuestionIndex);
        }

		public ISelectedTheoryQuestion FetchSpecificQuestion(int questionIndex)
		{
            if (questionIndex < 0 || questionIndex >= 5)
            {
                throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
            }
			CurrentQuestionIndex = questionIndex;

            return SelectedTheoryQuestions.FirstOrDefault(question => question.QuestionIndex == CurrentQuestionIndex);
		}

        //public void AnswerQuestion(int questionIndex, int[] answerIndexes, bool markForReview)
        //{
        //    if (questionIndex < 0 || questionIndex >= 5)
        //    {
        //        throw new BusinessRuleException(String.Format("Question Index [{0}] is invalid.", questionIndex));
        //    }

        //    var currentQuestion = SelectedTheoryQuestions.First(question => question.QuestionIndex == questionIndex);
        //    currentQuestion.SelectAnswers(answerIndexes);
        //    currentQuestion.MarkForReview(markForReview);
        //}


        int ITheoryComponent.CurrentQuestionIndex
        {
            get { throw new NotImplementedException(); }
        }
    }
}
