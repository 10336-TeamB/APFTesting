using System;
using System.Collections.Generic;
using APFTestingModel.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class AnswerTest
    {
        [TestMethod]
        public void Constructor_SetsCorrectValues()
        {
            //Arrange
            TheoryQuestion question = new MockTheoryQuestion();
            var questionId = Guid.NewGuid();
            question.Id = questionId;
            var answerDetails = new AnswerDetails("answer description", true);

            //Act
            Answer answer = new Answer(answerDetails, 1, question);

            var expectedAnswerDetail = "answer description";
            var expectedAnswerOrderIndex = 1;
            var expectedQuestionId = questionId;
            var expectedAnswerIsCorrect = true;

            var actualAnswerDetail = answer.Description;
            var actualAnswerOrderIndex = answer.DisplayOrderIndex;
            var actualAnswerQuestionId = answer.TheoryQuestion.Id;
            var actualAnswerIsCorrect = answer.IsCorrect;

            //Assert
            Assert.AreEqual(expectedAnswerDetail, actualAnswerDetail);
            Assert.AreEqual(expectedAnswerOrderIndex, actualAnswerOrderIndex);
            Assert.AreEqual(expectedQuestionId, actualAnswerQuestionId);
            Assert.AreEqual(expectedAnswerIsCorrect, actualAnswerIsCorrect);
        }

        [TestMethod]
        public void Edit_UpdatesValues()
        {
            //Arrange
            TheoryQuestion question = new MockTheoryQuestion();
            var questionId = Guid.NewGuid();
            question.Id = questionId;
            var answerId = Guid.NewGuid();
            var answerDetails = new AnswerDetails("answer description", true);
            var answerDetails2 = new AnswerDetails("answer description 2", false);

            Answer answer = new Answer(answerDetails, 1, question);

            //Act
            answer.Edit(answerDetails2, 2);

            var expectedAnswerDetail = "answer description 2";
            var expectedAnswerOrderIndex = 2;
            var expectedAnswerIsCorrect = false;

            var actualAnswerDetail = answer.Description;
            var actualAnswerOrderIndex = answer.DisplayOrderIndex;
            var ActualAnswerIsCorrect = answer.IsCorrect;

            //Assert
            Assert.AreEqual(expectedAnswerDetail, actualAnswerDetail);
            Assert.AreEqual(expectedAnswerOrderIndex, actualAnswerOrderIndex);
            Assert.AreEqual(expectedAnswerIsCorrect, ActualAnswerIsCorrect);
        }
    }
}
