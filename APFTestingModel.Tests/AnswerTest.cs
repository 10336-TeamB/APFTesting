using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class AnswerTest
    {
        [TestMethod]
        public void AnswerGetDescription()
        {
            // Assemble
            var fixture = new Answer();
            fixture.Description = "Hello world";
            var expected = "Hello world";
            var expected2 = "Hello Earth";

            // Act
            var actual = fixture.Description;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(expected2, actual);
        }
    }
}
