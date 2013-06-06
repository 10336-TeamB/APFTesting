using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class PracticalComponentTemplatePackerTests
    {
        //DONE
        
        [TestMethod]
        public void Activate_SetIsActiveToTrue()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePacker();

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
            var template = new PracticalComponentTemplatePacker();

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
            var template = new PracticalComponentTemplatePacker();

            //=== ACT ===
            template.Deactivate();

            //=== ASSERT ===
            var actual = template.AllowEditOrDelete;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void AllowEditOrDelete_WhenPracticalComponentPackersCountGreaterThanZero_ReturnFalse()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePacker();
            template.PracticalComponentPackers = new List<PracticalComponentPacker>()
            {
                new PracticalComponentPacker()
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
            var template = new PracticalComponentTemplatePacker();

            //=== ACT ===
            template.Activate();

            //=== ASSERT ===
            var actual = template.AllowEditOrDelete;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Edit_ValidValue_UpdateTemplate()
        {
            //=== ASSEMBLE ===
            var template = new PracticalComponentTemplatePacker();
            var expected = 10;

            //=== ACT ===
            template.Edit(expected);

            //=== ASSERT ===
            var actual = template.NumOfRequiredAssessmentTasks;
            Assert.AreEqual(expected, actual, "The current value of NumOfRequiredAssessmentTasks property does not equal the value provided to edit method.");
        }

        [TestMethod]
        public void ConstructorInt_AssignProperty()
        {
            //=== ASSEMBLE ===
            var expected = 10;
            
            //=== ACT ===
            var template = new PracticalComponentTemplatePacker(expected);

            //=== ASSERT ===
            var actual = template.NumOfRequiredAssessmentTasks;
            Assert.AreEqual(expected, actual, "The current value of NumOfRequiredAssessmentTasks property does not equal the value provided to the constructor.");
        }

    }
}
