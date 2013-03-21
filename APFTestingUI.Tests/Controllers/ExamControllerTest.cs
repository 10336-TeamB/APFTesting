using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APFTestingUI;
using APFTestingUI.Controllers;
using System.Web.Mvc;
using APFTestingUI.Models.Exam;

namespace APFTestingUI.Tests.Controllers {
    [TestClass]
    public class ExamControllerTest
    {
        private MockFacade _mockFacade;
        private ExamController _controller;

        [TestInitialize]
        public void TestInit()
        {
            _mockFacade = new MockFacade();
            _controller = new ExamController(_mockFacade);
        }

        [TestMethod]
        public void Start_GET_Returns_View() {
            // Arrange
            Guid candidateId = Guid.NewGuid();
            Guid examinerId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.Start(examinerId, candidateId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void FirstQuestion_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.FirstQuestion(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void NextQuestion_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.NextQuestion(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void PreviousQuestion_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.PreviousQuestion(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Resume_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.Resume(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Review_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();
            const int questionNumber = 1;

            //// Act
            ActionResult result = _controller.Review(examId, questionNumber);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Summary_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.Summary(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Result_GET_Returns_View()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            ActionResult result = _controller.Result(examId);

            //// Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void SubmitAnswer_redirects_to_NextQuestion()
        {
            // Arrange
            AnsweredQuestion question = new AnsweredQuestion { NavDirection = ExamAction.NextQuestion };

            //// Act
            RedirectToRouteResult result = (RedirectToRouteResult)_controller.SubmitAnswer(question);

            //// Assert
            Assert.AreEqual("NextQuestion", result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubmitAnswer_redirects_to_PreviousQuestion()
        {
            // Arrange
            AnsweredQuestion question = new AnsweredQuestion { NavDirection = ExamAction.PreviousQuestion };

            //// Act
            RedirectToRouteResult result = (RedirectToRouteResult)_controller.SubmitAnswer(question);

            //// Assert
            Assert.AreEqual("PreviousQuestion", result.RouteValues["action"]);
        }

        [TestMethod]
        public void SubmitAnswer_redirects_to_Summary()
        {
            // Arrange
            AnsweredQuestion question = new AnsweredQuestion { NavDirection = ExamAction.DisplaySummary };

            //// Act
            RedirectToRouteResult result = (RedirectToRouteResult)_controller.SubmitAnswer(question);

            //// Assert
            Assert.AreEqual("Summary", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Submit_redirects_to_Result()
        {
            // Arrange
            Guid examId = Guid.NewGuid();

            //// Act
            RedirectToRouteResult result = (RedirectToRouteResult)_controller.Submit(examId);

            //// Assert
            Assert.AreEqual("Result", result.RouteValues["action"]);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _controller.Dispose();
        }
    }
}
