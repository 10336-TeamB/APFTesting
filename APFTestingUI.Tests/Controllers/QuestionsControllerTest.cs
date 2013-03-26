using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APFTestingUI.Controllers;
using APFTestingUI.Models.Exam;

namespace APFTestingUI.Tests.Controllers
{
    [TestClass]
    public class QuestionsControllerTest
    {
        private MockFacade _mockFacade;
        private QuestionsController _controller;

        [TestInitialize]
        public void TestInit()
        {
            _mockFacade = new MockFacade();
            _controller = new QuestionsController(_mockFacade);
        }

        [TestMethod]
        public void Post_NextQuestion_returns_QuestionDisplayItem()
        {
            // Arrange
            Guid examId = Guid.NewGuid();
            AnsweredQuestion answeredQuestion = new AnsweredQuestion() { NavButton = "Next Question", ExamId = examId };

            //// Act
            var result = _controller.Post(answeredQuestion);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(QuestionDisplayItem));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller.Dispose();
        }
    }
}
