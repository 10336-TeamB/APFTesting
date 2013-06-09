using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    /// <summary>
    /// Summary description for SelectedAssessmentTaskTest
    /// </summary>
    [TestClass]
    public class SelectedAssessmentTaskTest
    {
        [TestMethod]
        public void RecordResultTest()
        {
            //Assemble
            var selectedAssessmentTask = new SelectedAssessmentTask(new AssessmentTaskPilot() { Details = "Details", MaxScore = 10, Title = "Hello World" });
            
            //Action
            selectedAssessmentTask.RecordResult(new PilotPracticalResult() { Comment = "Comment", Score = 8 });

            //Assert
            Assert.AreEqual("Comment", selectedAssessmentTask.Comment);
            Assert.AreEqual(8, selectedAssessmentTask.Score);
        }
    }
}
