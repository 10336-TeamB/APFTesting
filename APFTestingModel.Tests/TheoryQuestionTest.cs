using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APFTestingModel;

namespace APFTestingModel.Tests
{

    [TestClass]
    public class TheoryQuestionTest
    {      
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var dummyAnswers = new List<Answer>();
            dummyAnswers.Add(new Answer() { Description = "Over 9000" });
            var fixture = new TheoryQuestionPilot();
            fixture.Answers = dummyAnswers;
            var expected = dummyAnswers;

            // Act
            // Assert


            //
            // TODO: Add test logic here
            //
        }
    }
}
