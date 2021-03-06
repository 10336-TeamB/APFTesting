﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    abstract internal class ExamManager
    {
        protected PracticalComponentManager practicalComponentManager;
        protected TheoryComponentManager theoryComponentManager;

		public TheoryQuestion CreateTheoryQuestion(TheoryQuestionDetails questionDetails)
		{
			return theoryComponentManager.CreateTheoryQuestion(questionDetails);
		}

        public abstract Exam GenerateExam(Guid examinerId, Guid candidateId);
        public TheoryComponentFormat CreateTheoryExamFormat(int numberOfQuestions, int passMark, int timeLimit, int availableQuestions)
        {
            return theoryComponentManager.CreateTheoryExamFormat(numberOfQuestions, passMark, timeLimit, availableQuestions);
        }
    }
}
