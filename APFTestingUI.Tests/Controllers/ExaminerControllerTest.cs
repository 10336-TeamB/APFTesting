//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using APFTestingUI;
//using APFTestingUI.Controllers;
//using System.Web.Mvc;

//namespace APFTestingUI.Tests.Controllers {
//    [TestClass]
//    public class ExaminerControllerTest
//    {
//        private MockFacade _mockFacade;
//        private ExaminerController _controller;

//        [TestInitialize]
//        public void TestInit()
//        {
//            _mockFacade = new MockFacade();
//            _controller = new ExaminerController(_mockFacade);
//        }

//        [TestMethod]
//        public void Index_GET_Returns_View() {
//            // Arrange

//            //// Act
//            var result = _controller.Index();

//            //// Assert
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOfType(result, typeof(ViewResult));
//        }

//        [TestCleanup]
//        public void TestCleanup()
//        {
//            _controller.Dispose();
//        }
//    }
//}
