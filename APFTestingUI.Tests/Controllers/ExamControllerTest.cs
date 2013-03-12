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

namespace APFTestingUI.Tests.Controllers {
    [TestClass]
    public class ExamControllerTest {
        [TestMethod]
        public void Start_GET_Returns_View() {
            // Arrange
            ExamController controller = new ExamController();
            Guid guid = Guid.NewGuid();

            // Act
            ActionResult result = controller.Start(guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        public void NextQuestion_GET_Returns_View()
        {
            // Arrange
            ExamController controller = new ExamController();
            Guid guid = Guid.NewGuid();

            // Act
            ActionResult result = controller.NextQuestion(guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
