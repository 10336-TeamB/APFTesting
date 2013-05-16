﻿using System;
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



        #region Properties

        IEnumerable<IAnswer> ITheoryQuestion.Answers
        {
            get { return Answers; }
        }

        public bool editableOrDeletable
        {
            get
            {
                return SelectedTheoryQuestions.Count == 0;
            }
        }

        #endregion



        #region Methods

		public List<Answer> Edit(TheoryQuestionDetails questionDetails)
        {
            Description = questionDetails.Description;
            var answersToDelete = editAnswers(questionDetails.Answers);
            NumberOfCorrectAnswers = Answers.Count(a => a.IsCorrect == true);
            IsActive = true;
            ImagePath = questionDetails.ImagePath;
            Category = questionDetails.Category;

			return answersToDelete;
        }

        private void constructAnswers(List<AnswerDetails> answers)
        {
            if (Answers == null) Answers = new List<Answer>();
            for (int i = 0; i < answers.Count; i++)
            {
				Answer newAnswer;
				if (Answers == null)
				{
					newAnswer = new Answer(answers[i], 1, this);
				}
				else
				{
					newAnswer = new Answer(answers[i], Answers.Count + 1, this);
				}
				
                Answers.Add(newAnswer);
            }

        }

		private List<Answer> editAnswers(List<AnswerDetails> answerDetails)
        {
            int indexCounter = 0;
            List<Answer> deletionList = new List<Answer>();

			Answers = Answers.OrderBy(a => a.DisplayOrderIndex).ToList();
			
			foreach (var answer in Answers)
            {
                bool exists = false;
                for (int i = 0; i < answerDetails.Count; i++)
                {
                    if (answer.Id == answerDetails[i].Id)
                    {
                        exists = true;
                        ++indexCounter;
                        answer.Edit(answerDetails[i], indexCounter);
                        answerDetails.Remove(answerDetails[i]);
                        break;
                    }
                }
                if (!exists)
                {
                    deletionList.Add(answer);
                }
            }
            //Remove Answers elements that do not exist in the answerDetails
            foreach (var answer in deletionList)
            {
                Answers.Remove(answer);
            }
            
			//New Answers
			if (answerDetails.Count > 0)
            {
                constructAnswers(answerDetails);
            }

			return deletionList;
        }

        #endregion

        

        

        //public void Delete(Facade facade)
        //{
        //    if (SelectedTheoryQuestions.Count == 0)
        //    {
        //        foreach (var answer in Answers)
        //        {
        //            facade.DeleteAnswer(answer);
        //        }
        //        facade.DeleteTheoryQuestion(this);
        //    }
        //}
    }
}
