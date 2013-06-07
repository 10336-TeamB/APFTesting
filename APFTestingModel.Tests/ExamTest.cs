using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    /// <summary>
    /// Summary description for ExamTest
    /// </summary>
    [TestClass]
    public class ExamTest
    {
        [TestMethod]
        public void FetchTheoryFormatSuccessfully()
        {
            //Assemble
            Exam exam = new ExamPilot(Guid.NewGuid(), Guid.NewGuid(), new TheoryComponentPilot(new TheoryComponentFormatPilot()), null);
            
            //Act
            TheoryComponentFormatPilot format = (TheoryComponentFormatPilot)exam.FetchTheoryComponentFormat();

            //Assert
            Assert.AreNotEqual(format, null);
        }

        [TestMethod]
        public void FetchTheoryFormatUnSuccessfully()
        {
            //Assemble
            Exam exam = new ExamPilot(Guid.NewGuid(), Guid.NewGuid(), new TheoryComponentPilot(new TheoryComponentFormatPilot()), null);
            TheoryComponentFormatPilot nonNullFormat = (TheoryComponentFormatPilot)exam.FetchTheoryComponentFormat(), format;
            
            //Act and Assert
            exam.ExamStatus = ExamStatus.EmailInProgress;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.ExamCompleted;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.ExamVoided;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.NoExam;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.PracticalComponentCompleted;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.SendingEmailFailed;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.TheoryFailed;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.TheoryInProgress;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);

            //Act and Assert
            exam.ExamStatus = ExamStatus.TheoryPassed;
            format = nonNullFormat;
            try
            {
                exam.FetchTheoryComponentFormat();
            }
            catch
            {
                format = null;
            }
            Assert.AreEqual(format, null);
        }

        [TestMethod]
        public void FetchNextQuestionSuccessfully()
        {
            //Assemble
            TheoryComponentPilot theoryComponent = new TheoryComponentPilot(new TheoryComponentFormatPilot() { NumberOfQuestions = 6 });
            List<SelectedTheoryQuestion> questions = new List<SelectedTheoryQuestion>();
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 1 });
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 2 });
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 3 });
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 4 });
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 5 });
            questions.Add(new SelectedTheoryQuestion() { QuestionIndex = 6 });

            theoryComponent.SelectedTheoryQuestions = questions;
            Exam exam = new ExamPilot(Guid.NewGuid(), Guid.NewGuid(), theoryComponent, null);
            exam.ExamStatus = ExamStatus.TheoryInProgress;
            SelectedTheoryQuestion question;

            //Act
            try
            {
                question = exam.FetchNextQuestion();
            }
            catch (BusinessRuleException)
            {
                question = null;
            }

            //Assert
            Assert.AreNotEqual(question, null);
        }
    }
}
