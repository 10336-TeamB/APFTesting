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

    }
}
