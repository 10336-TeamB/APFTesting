using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class AssessmentTaskPilotTest
    {
        [TestMethod]
        public void EmptyCtr_AllValuesDefault()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot();
            
            // Act
            var title = assessmentTask.Title;
            var details = assessmentTask.Details;
            var maxScore = assessmentTask.MaxScore;

            // Assert
            Assert.IsNull(title);
            Assert.IsNull(details);
            Assert.AreEqual(0, maxScore);
        }

        [TestMethod]
        public void CtrWithDetails_AllValuesSet()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot(createAssessmentTaskDetails());

            // Act
            var title = assessmentTask.Title;
            var details = assessmentTask.Details;
            var maxScore = assessmentTask.MaxScore;

            // Assert
            Assert.AreEqual("Task 1", title);
            Assert.AreEqual("Details", details);
            Assert.AreEqual(9, maxScore);
        }

        private AssessmentTaskPilotDetails createAssessmentTaskDetails()
        {
            return new AssessmentTaskPilotDetails()
                {
                    Title = "Task 1",
                    Details = "Details",
                    MaxScore = 9
                };
        }

        [TestMethod]
        public void Edit_AllValuesChanged()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot();
            // Act
            assessmentTask.Edit(createAssessmentTaskDetails());
            var title = assessmentTask.Title;
            var details = assessmentTask.Details;
            var maxScore = assessmentTask.MaxScore;

            // Assert
            Assert.AreEqual("Task 1", title);
            Assert.AreEqual("Details", details);
            Assert.AreEqual(9, maxScore);
        }

        [TestMethod]
        public void EnableChange_True_NoSelectedAssessmentTasks()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot();
            // Act
            var result = assessmentTask.EnableChange;
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EnableChange_False_OneSelectedAssessmentTask()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot
                {
                    SelectedAssessmentTasks = new List<SelectedAssessmentTask>
                        {
                            new SelectedAssessmentTask()
                        }
                };
            // Act
            var result = assessmentTask.EnableChange;
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Delete_ThrowsException_OneSelectedAssessmentTask()
        {
            // Assemble
            var assessmentTask = new AssessmentTaskPilot
                {
                    SelectedAssessmentTasks = new List<SelectedAssessmentTask>
                        {
                            new SelectedAssessmentTask()
                        }
                };

            // Act
            assessmentTask.Delete(dummyDeleteDelegate);

            // Assert
            // BusinessRuleException will be thrown
        }

        private void dummyDeleteDelegate<T>(T entity) { }
    }
}
