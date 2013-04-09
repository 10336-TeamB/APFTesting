using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class CandidatePackerTest
    {
        // NewExamPossbile test methods
        // True when ExamStatus = NoExam
        // False when ExamStatus = NewExam
        // False when ExamStatus = TheoryInProgress
        // True when ExamStatus = TheoryFailed
        // False when ExamStatus = TheoryPassed
        // False when ExamStatus = PracticalEntered
        // False when ExamStatus = ExamCompleted 
        // True when ExamStatus = ExamVoided

        [TestMethod]
        public void NewExamPossible_True_NoExam()
        {
            // Arrange
            var exam = new ExamPacker { ExamStatus = ExamStatus.NoExam };
            var examList = new List<ExamPacker>();
            examList.Add(exam);
            var candidate = new CandidatePacker { ExamPackers = examList };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NewExamPossible_False_NewExam()
        {
            // Arrange
            var exam = new ExamPacker { ExamStatus = ExamStatus.NewExam };
            var examList = new List<ExamPacker>();
            examList.Add(exam);
            var candidate = new CandidatePacker { ExamPackers = examList };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }
    }
}
