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
            Assert.AreEqual(expectedQuestionCount, actualQuestionCount,"QuestionCount property did not equal expected value.");
            Assert.AreEqual(expectedPassMark, actualPassMark, "PassMark property did not equal expected value.");
            Assert.AreEqual(expectedTimeLimit, actualTimeLimit, "TimeLimit property did not equal expected value.");
        }

		[TestMethod]
		public void Activate_SetIsActiveToTrue()
		{
			//=== ASSEMBLE ===
			var format = new TheoryComponentFormatPilot();

			//=== ACT ===
			format.Activate();

			//=== ASSERT ===
			var actual = format.IsActive;
			Assert.IsTrue(actual, "The value of IsTrue property is not the expected value of True.");

		}

		[TestMethod]
		public void Deactivate_SetIsActiveToFalse()
		{
			//=== ASSEMBLE ===
			var format = new TheoryComponentFormatPilot();

			//=== ACT ===
			format.Deactivate();

			//=== ASSERT ===
			var actual = format.IsActive;
			Assert.IsFalse(actual, "The value of IsTrue property is not the expected value of False.");
		}

		[TestMethod]
		public void AllowEditOrDelete_WhenConditionTrue_ReturnTrue()
		{
			//=== ASSEMBLE ===
			var format = new TheoryComponentFormatPilot();

			//=== ACT ===
			format.Deactivate();

			//=== ASSERT ===
			var actual = format.AllowEditOrDelete;
			Assert.IsTrue(actual);
		}

		[TestMethod]
		public void AllowEditOrDelete_WhenPracticalComponentPilotsCountGreaterThanZero_ReturnFalse()
		{
			//=== ASSEMBLE ===
			var format = new TheoryComponentFormatPilot();
			format.TheoryComponents = new List<TheoryComponent>()
			{
				new TheoryComponentPilot()
			};

			//=== ACT ===
			format.Deactivate();

			//=== ASSERT ===
			var actual = format.AllowEditOrDelete;
			Assert.IsFalse(actual);

		}

		[TestMethod]
		public void AllowEditOrDelete_WhenIsActiveIsTrue_ReturnFalse()
		{
			//=== ASSEMBLE ===
			var format = new TheoryComponentFormatPilot();

			//=== ACT ===
			format.Activate();

			//=== ASSERT ===
			var actual = format.AllowEditOrDelete;
			Assert.IsFalse(actual);
		}

    }
}
