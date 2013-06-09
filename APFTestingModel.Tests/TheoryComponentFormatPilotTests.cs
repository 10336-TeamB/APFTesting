using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class TheoryComponentFormatPilotTests
    {
        [TestMethod]
        public void ConstructorIntIntInt_InitializeProperties()
        {
            // Assemble
            var expectedQuestionCount = 10;
            var expectedPassMark = 10;
            var expectedTimeLimit = 0;
            var format = new TheoryComponentFormatPilot(expectedQuestionCount, expectedPassMark, expectedTimeLimit);

            // Act
            var actualQuestionCount = format.NumberOfQuestions;
            var actualPassMark = format.PassMark;
            var actualTimeLimit = format.TimeLimit;
            
            // Assert
            Assert.AreEqual(expectedQuestionCount, actualQuestionCount);
            Assert.AreEqual(expectedPassMark, actualPassMark);
            Assert.AreEqual(expectedTimeLimit, actualTimeLimit);
        }
    }
}
