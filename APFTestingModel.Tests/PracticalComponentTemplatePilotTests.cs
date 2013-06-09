using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class PracticalComponentTemplatePilotTests
    {
        [TestMethod]
        public void ConstructorList_AssignTasks()
        {
            //=== ASSEMBLE ===
            var expectedListCount = 1;
            List<AssessmentTaskPilot> tasks = new List<AssessmentTaskPilot>();
            var taskA = new AssessmentTaskPilot() { Details = "TaskA" };
            tasks.Add(taskA);

            //=== ACT ===
            var template = new PracticalComponentTemplatePilot(tasks);

            //=== ASSERT ===
            var actualListCount = tasks.Count;
            Assert.AreEqual(expectedListCount, actualListCount, "AssessmentTaskPilots count does not equal to the count of AssessmentTaskPilot list assigned by constructor.");
        }



        [TestMethod]
        public void Activate_SetIsActiveToTrue()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();

            //=== ACT ===
            template.Activate();

            //=== ASSERT ===
            var actual = template.IsActive;
            Assert.IsTrue(actual, "The value of IsTrue property is not the expected value of True.");
        }



        [TestMethod]
        public void Deactivate_SetIsActiveToFalse()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();

            //=== ACT ===
            template.Deactivate();

            //=== ASSERT ===
            var actual = template.IsActive;
            Assert.IsFalse(actual, "The value of IsTrue property is not the expected value of False.");
        }



        [TestMethod]
        public void AllowEditOrDelete_WhenConditionTrue_ReturnTrue()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();

            //=== ACT ===
            template.Deactivate();

            //=== ASSERT ===
            var actual = template.AllowEditOrDelete;
            Assert.IsTrue(actual);
        }



        [TestMethod]
        public void AllowEditOrDelete_WhenPracticalComponentPilotsCountGreaterThanZero_ReturnFalse()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();
            template.PracticalComponentPilots = new List<PracticalComponentPilot>()
            {
                new PracticalComponentPilot()
            };

            //=== ACT ===
            template.Deactivate();

            //=== ASSERT ===
            var actual = template.AllowEditOrDelete;
            Assert.IsFalse(actual);
        }



        [TestMethod]
        public void AllowEditOrDelete_WhenIsActiveIsTrue_ReturnFalse()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();

            //=== ACT ===
            template.Activate();

            //=== ASSERT ===
            var actual = template.AllowEditOrDelete;
            Assert.IsFalse(actual);
        }



        [TestMethod]
        public void Edit_ModifiedTasks_UpdateTaskList()
        {
            //=== ASSEMBLE ===
            //Tasks
            var TaskA = new AssessmentTaskPilot() { Title = "TaskA" };
            var TaskB = new AssessmentTaskPilot() { Title = "TaskB" };
            var TaskC = new AssessmentTaskPilot() { Title = "TaskC" };
            var TaskD = new AssessmentTaskPilot() { Title = "TaskD" };
            //Current List
            var currentList = new List<AssessmentTaskPilot>()
            {
                TaskC,
                TaskB,
                TaskA
            };
            currentList = currentList.OrderBy(e => e.Title).ToList();
            //New List
            var expectedList = new List<AssessmentTaskPilot>()
            {
                TaskA,
                TaskB,
                TaskD
            };
            expectedList = expectedList.OrderBy(e => e.Title).ToList();
            System.Collections.ICollection expected = expectedList.ToList();
            //Object to Test
            var template = new PracticalComponentTemplatePilot(currentList);
            template.PracticalComponentPilots = new List<PracticalComponentPilot>();

            //=== ACT ===
            template.Edit(expectedList);

            //=== ASSERT===
            System.Collections.ICollection actual = template.AssessmentTaskPilots.ToList();
            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Edit_NotEditable_ThrowError()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePilot();
            template.Activate();
            var taskList = new List<AssessmentTaskPilot>();

            //=== ACT ===
            template.Edit(taskList);

            //=== ASSERT===
            //Expected Expection
        }
    }
}
