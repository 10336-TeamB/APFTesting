﻿using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingUI.Tests
{
    internal class MockSelectedTheoryQuestion : ISelectedTheoryQuestion
    {
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public string Description
        {
            get { return "This is the question description"; }
        }

        public int NumberOfCorrectAnswers
        {
            get { return 1; }
        }

        public IEnumerable<IPossibleAnswer> PossibleAnswers
        {
            get
            {
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
                yield return new MockPossibleAnswer();
            }
        }

        public int QuestionIndex
        {
            get { return 1; }
        }

        public bool IsMarkedForReview
        {
            get { return false; }
        }

        public bool IsAnswered
        {
            get { return false; }
        }

        public bool IsLastQuestion
        {
            get { return false; }
        }


        public bool IsCorrect
        {
            get { return true; }
        }


        public int TotalNumOfQuestions
        {
            get { return 10; }
        }


        public string ImagePath
        {
            get { throw new NotImplementedException(); }
        }


        public ExamType ExamType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
