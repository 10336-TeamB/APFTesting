using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class SelectedTheoryQuestionTest
    {
        [TestMethod]
        public void CompareTo_ReturnsNegative_IndexLessThanComparator()
        {
            //Assemble
            SelectedTheoryQuestion smallerQuestion = new SelectedTheoryQuestion { QuestionIndex = 2 };
            SelectedTheoryQuestion largerQuestion = new SelectedTheoryQuestion { QuestionIndex = 4 };

            //Act
            var result = smallerQuestion.CompareTo(largerQuestion);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareTo_ReturnsPositive_IndexGreaterThanComparator()
        {
            //Assemble
            SelectedTheoryQuestion smallerQuestion = new SelectedTheoryQuestion { QuestionIndex = 2 };
            SelectedTheoryQuestion largerQuestion = new SelectedTheoryQuestion { QuestionIndex = 4 };

            //Act
            var result = largerQuestion.CompareTo(smallerQuestion);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareTo_ReturnsZero_IndexSameAsComparator()
        {
            //Assemble
            SelectedTheoryQuestion question1 = new SelectedTheoryQuestion { QuestionIndex = 2 };
            SelectedTheoryQuestion question2 = new SelectedTheoryQuestion { QuestionIndex = 2 };

            //Act
            var result = question1.CompareTo(question2);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExamType_ReturnsPilot_TheoryComponentIsPilot()
        {
            //Assemble
            var question = new SelectedTheoryQuestion() { TheoryComponent = new TheoryComponentPilot() };

            //Act
            var result = question.ExamType;

            //Assert
            Assert.AreEqual(ExamType.PilotExam, result);
        }

        [TestMethod]
        public void ExamType_ReturnsPacker_TheoryComponentIsPacker()
        {
            //Assemble
            var question = new SelectedTheoryQuestion() { TheoryComponent = new TheoryComponentPacker() };

            //Act
            var result = question.ExamType;

            //Assert
            Assert.AreEqual(ExamType.PackerExam, result);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void ExamType_ThrowsException_TheoryComponentTypeUnknown()
        {
            //Assemble
            var question = new SelectedTheoryQuestion() { };

            //Act
            var result = question.ExamType;

            //Assert
            // Should throw BusinessRuleException
        }
    }
}
