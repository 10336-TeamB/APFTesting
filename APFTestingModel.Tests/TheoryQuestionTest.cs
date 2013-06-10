using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APFTestingModel;
using APFTestingModel.Tests.Mocks;
using System.Diagnostics;
using System.Linq;

namespace APFTestingModel.Tests
{

    [TestClass]
    public class TheoryQuestionTest
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_ThrowsExceptionIfLessThanOneQuestionDetail()
        {
            //Arrange
            var answers = new List<AnswerDetails>();
            answers.Add(new AnswerDetails("answer description 1", true));

            //Act
            MockTheoryQuestion question = new MockTheoryQuestion(new TheoryQuestionDetails("description", "image path", TheoryQuestionCategory.General, answers));

            //Assert
            //Exception is throw
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void Constructor_ThrowsExceptionIfNoCorrectAnswersGiven()
        {
            //Arrange
            var answers = new List<AnswerDetails>();
            answers.Add(new AnswerDetails("answer description 1", false));
            answers.Add(new AnswerDetails("answer description 2", false));


            //Act
            MockTheoryQuestion question = new MockTheoryQuestion(new TheoryQuestionDetails("description", "image path", TheoryQuestionCategory.General, answers));

            //Assert
            //Exception is throw
        }

        [TestMethod]
        public void Edit_UpdatesTheoryQuestionDetails()
        {
            //Arrange
            MockTheoryQuestion question = new MockTheoryQuestion() { Description = "description of question", Category = TheoryQuestionCategory.General, Id = Guid.NewGuid(), IsActive = true, NumberOfCorrectAnswers = 1, Answers = null};
            
            List<Answer> answers = new List<Answer>();
            AnswerDetails a1 = new AnswerDetails("answer 1", true, Guid.NewGuid());
            AnswerDetails a2 = new AnswerDetails("answer 2", false, Guid.NewGuid());
            AnswerDetails a3 = new AnswerDetails("answer 3", false, Guid.NewGuid());
            Answer answer1 = new Answer(a1, 1, question);
            Answer answer2 = new Answer(a2, 2, question);
            Answer answer3 = new Answer(a3, 3, question);
            answers.Add(answer1);
            answers.Add(answer2);
            answers.Add(answer3);

            question.Answers = answers;

            Guid answerGuid1 = Guid.NewGuid();
            Guid answerGuid2 = Guid.NewGuid();
            Guid answerGuid3 = Guid.NewGuid();

            ICollection<AnswerDetails> answerDetailsList = new List<AnswerDetails>();
            AnswerDetails a4 = new AnswerDetails("answer 4", false, answerGuid1);
            AnswerDetails a5 = new AnswerDetails("answer 5", false, answerGuid2);
            AnswerDetails a6 = new AnswerDetails("answer 6", true, answerGuid3);
            answerDetailsList.Add(a4);
            answerDetailsList.Add(a5);
            answerDetailsList.Add(a6);

            //Act
            TheoryQuestionDetails details = new TheoryQuestionDetails("new description", "images.jpg", TheoryQuestionCategory.General, answerDetailsList);
            question.Edit(details);

            var expectedDescription = "new description";
            var expectedImagePath = "images.jpg";
            var expectedCategory = TheoryQuestionCategory.General;
            List<AnswerDetails> expectedAnswerDetailsList = (List<AnswerDetails>)answerDetailsList;

            var actualDescription = question.Description;
            var actualImagePath = question.ImagePath;
            var actualCategory = question.Category;
            var actualAnswers = question.Answers;
            List<AnswerDetails> actualAnswerDetailsList = new List<AnswerDetails>();
            foreach (var answer in actualAnswers)
            {
                actualAnswerDetailsList.Add(new AnswerDetails(answer.Description, answer.IsCorrect, answer.Id));
            }

            //Assert
            Assert.AreEqual(expectedDescription, actualDescription);
            Assert.AreEqual(expectedImagePath, actualImagePath);
            Assert.AreEqual(expectedCategory, actualCategory);
            Assert.AreEqual(expectedAnswerDetailsList.Count, actualAnswerDetailsList.Count);
            for (int i = 0; i < actualAnswerDetailsList.Count; i++)
            {
                Assert.AreEqual(expectedAnswerDetailsList[i].Description, actualAnswerDetailsList[i].Description);
                Assert.AreEqual(expectedAnswerDetailsList[i].IsCorrect, actualAnswerDetailsList[i].IsCorrect);
            }
        }

        [TestMethod]
        public void ToggleActivation_UpdatesStatus()
        {
            //Arrange
            MockTheoryQuestion question = new MockTheoryQuestion() { IsActive = false };

            //Act
            question.toggleActivation();
            bool expected = true;
            bool actual = question.IsActive;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditableOrDeletable_ReturnsTrueIfHasNoSelectedTheoryQuestion()
        {
            //Arrange
            MockTheoryQuestion question = new MockTheoryQuestion();

            //Act
            var expected = true;
            var actual = question.EditableOrDeletable;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditableOrDeletable_ReturnsFalseIfHasSelectedTheoryQuestion()
        {
            //Arrange
            MockTheoryQuestion question = new MockTheoryQuestion();
            var selectedTheoryQuestions = new List<SelectedTheoryQuestion>();
            selectedTheoryQuestions.Add(new SelectedTheoryQuestion());

            //Act
            question.SelectedTheoryQuestions = selectedTheoryQuestions;
            var expected = false;
            var actual = question.EditableOrDeletable;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
