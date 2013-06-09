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
        //TODO: Needs naming
        public void TestMethod1()
        {
            // Arrange
            var dummyAnswers = new List<Answer>();
            dummyAnswers.Add(new Answer() { Description = "Over 9000" });
            var fixture = new TheoryQuestionPilot();
            fixture.Answers = dummyAnswers;
           
            // Act
            var expected = dummyAnswers;
            var actual = fixture.Answers;
            
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
