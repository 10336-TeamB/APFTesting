using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APFTestingModel;
using System.Collections.Generic;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class TheoryComponentTest
    {
        ICollection<SelectedTheoryQuestion> createMockQuestions()
        {
            ICollection<SelectedTheoryQuestion> mock = new List<SelectedTheoryQuestion>();
            mock.Add(new SelectedTheoryQuestion() { QuestionIndex = 0 });
            mock.Add(new SelectedTheoryQuestion() { QuestionIndex = 1 });
            mock.Add(new SelectedTheoryQuestion() { QuestionIndex = 2 });
            mock.Add(new SelectedTheoryQuestion() { QuestionIndex = 3 });
            mock.Add(new SelectedTheoryQuestion() { QuestionIndex = 4 });
            return mock;
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void FetchSpecificQuestionTest()
        {
            // Arrange
            TheoryComponentPilot fixture = new TheoryComponentPilot(new TheoryComponentFormatPilot(5, 80));
            fixture.SelectedTheoryQuestions = createMockQuestions();
            
            //// Act
            ISelectedTheoryQuestion firstQuestion = fixture.FetchSpecificQuestion(4);
       
            //// Assert
            Assert.IsNotNull(firstQuestion);
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void FetchNextQuestionTest()
        {
            // Arrange
            TheoryComponentPilot fixture = new TheoryComponentPilot(new TheoryComponentFormatPilot(5, 80));
            fixture.SelectedTheoryQuestions = createMockQuestions();

            //// Act
            //This should never fail
            ISelectedTheoryQuestion question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();
            question = fixture.FetchNextQuestion();

            //// Assert
            Assert.IsNotNull(question);
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void FetchPreviousQuestionTest()
        {
            // Arrange
            TheoryComponentPilot fixture = new TheoryComponentPilot(new TheoryComponentFormatPilot(5, 80));
            fixture.SelectedTheoryQuestions = createMockQuestions();

            //// Act
            //This should never fail
            ISelectedTheoryQuestion question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();
            question = fixture.FetchPreviousQuestion();

            //// Assert
            Assert.IsNotNull(question);
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void FetchCurrentQuestionTest()
        {
            // Arrange
            TheoryComponentPilot fixture = new TheoryComponentPilot(new TheoryComponentFormatPilot(5, 80));
            fixture.SelectedTheoryQuestions = createMockQuestions();

            //// Act
            ISelectedTheoryQuestion question = fixture.FetchCurrentQuestion();

            //// Assert
            Assert.IsNotNull(question);
        }

        [TestMethod]
        //[ExpectedException(typeof(BusinessRuleException))]
        public void AnswerQuestionTest()
        {
            // Arrange
            TheoryComponentPilot fixture = new TheoryComponentPilot(new TheoryComponentFormatPilot(5, 80));
            fixture.SelectedTheoryQuestions = createMockQuestions();

            //// Act
            fixture.AnswerQuestion(1, new int[] { 1, 2 }, false);

            //// Assert
           
        }
    }
}
