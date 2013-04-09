using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    /// <summary>
    /// Summary description for ExamTest
    /// </summary>
    [TestClass]
    public class ExamTest
    {
        [TestMethod]
        public void OnExamStatusChangedTest()
        {
            //Assemble
            MockTheoryComponentPilot mockTheoryComponent = new MockTheoryComponentPilot();
            var exam = new ExamPilot(Guid.NewGuid(), Guid.NewGuid(), new TheoryComponentPilot(new TheoryComponentFormatPilot() { NumberOfQuestions = 10, PassMark = 80 }), new PracticalComponentPilot());
        
            //Action
            exam.ExamStatus = ExamStatus.TheoryPassed;
            
            //Assert
            Assert.AreEqual((new TheoryComponentCompleted()).GetType(), exam.ExamState.GetType());
        }

        [TestMethod]

    }
}
