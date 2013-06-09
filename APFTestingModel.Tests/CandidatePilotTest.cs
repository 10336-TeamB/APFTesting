using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class CandidatePilotTest
    {
        [TestMethod]
        public void CandidatePilot_EmptyCtr_AllDefault()
        {
            //Assemble
            var candidate = new CandidatePilot();

            //Assert
            Assert.IsNull(candidate.FirstName);
            Assert.IsNull(candidate.LastName);
            Assert.AreEqual(DateTime.MinValue, candidate.DateOfBirth);
            Assert.IsNull(candidate.Address);
            Assert.IsNull(candidate.ARN);
            Assert.IsNull(candidate.PhoneNumber);
            Assert.IsNull(candidate.MobileNumber);
            Assert.IsNull(candidate.Email);
            Assert.AreEqual((PilotLicenceType)0, candidate.PilotLicenceType);
            Assert.IsFalse(candidate.InstrumentRating);
            Assert.AreEqual((PilotMedicalType)0, candidate.PilotMedicalType);
            Assert.AreEqual(DateTime.MinValue, candidate.PilotMedicalExpiryDate);
            Assert.IsFalse(candidate.ValidBFR);
        }

        [TestMethod]
        public void CandidatePilot_CtrWithDetails_ValuesCorrectlyAssigned()
        {
            // Assemble
            var guid = Guid.NewGuid();
            var candidate = new CandidatePilot(createPilotDetails(), guid);

            // Assert
            Assert.AreEqual(guid, candidate.CreatedBy);
            Assert.AreEqual("Adam", candidate.FirstName);
            Assert.AreEqual("Smith", candidate.LastName);
            Assert.AreEqual(new DateTime(1950, 1, 1), candidate.DateOfBirth);
            Assert.AreEqual("Unit 1", candidate.Address.Address1);
            Assert.AreEqual("1 Test Drive", candidate.Address.Address2);
            Assert.AreEqual("Aardvark Central", candidate.Address.Suburb);
            Assert.AreEqual("AAA", candidate.Address.State);
            Assert.AreEqual("0001", candidate.Address.Postcode);
            Assert.AreEqual("000001", candidate.ARN);
            Assert.AreEqual("0000000001", candidate.PhoneNumber);
            Assert.AreEqual("0400000001", candidate.MobileNumber);
            Assert.AreEqual("a@a.com", candidate.Email);
            Assert.AreEqual(PilotLicenceType.CPL, candidate.PilotLicenceType);
            Assert.IsTrue(candidate.InstrumentRating);
            Assert.AreEqual(PilotMedicalType.ClassOne, candidate.PilotMedicalType);
            Assert.AreEqual(new DateTime(2001, 1, 1), candidate.PilotMedicalExpiryDate);
            Assert.IsTrue(candidate.ValidBFR);
        }

        [TestMethod]
        public void CandidatePilot_Edit_AllValuesChanged()
        {
            // Assemble
            var candidate = new CandidatePilot();
            // Act

            candidate.Edit(createPilotDetails());

            // Assert
            Assert.AreEqual("Adam", candidate.FirstName);
            Assert.AreEqual("Smith", candidate.LastName);
            Assert.AreEqual(new DateTime(1950, 1, 1), candidate.DateOfBirth);
            Assert.AreEqual("Unit 1", candidate.Address.Address1);
            Assert.AreEqual("1 Test Drive", candidate.Address.Address2);
            Assert.AreEqual("Aardvark Central", candidate.Address.Suburb);
            Assert.AreEqual("AAA", candidate.Address.State);
            Assert.AreEqual("0001", candidate.Address.Postcode);
            Assert.AreEqual("000001", candidate.ARN);
            Assert.AreEqual("0000000001", candidate.PhoneNumber);
            Assert.AreEqual("0400000001", candidate.MobileNumber);
            Assert.AreEqual("a@a.com", candidate.Email);
            Assert.AreEqual(PilotLicenceType.CPL, candidate.PilotLicenceType);
            Assert.IsTrue(candidate.InstrumentRating);
            Assert.AreEqual(PilotMedicalType.ClassOne, candidate.PilotMedicalType);
            Assert.AreEqual(new DateTime(2001, 1, 1), candidate.PilotMedicalExpiryDate);
            Assert.IsTrue(candidate.ValidBFR);
        }

        private CandidatePilotDetails createPilotDetails()
        {
            return new CandidatePilotDetails {
                FirstName = "Adam",
                LastName = "Smith",
                DateOfBirth = new DateTime(1950, 1, 1),
                Address1 = "Unit 1",
                Address2 = "1 Test Drive",
                Suburb = "Aardvark Central",
                State = "AAA",
                Postcode = "0001",
                ARN = "000001",
                Phone = "0000000001",
                Mobile = "0400000001",
                Email = "a@a.com",
                PilotLicenceType = PilotLicenceType.CPL,
                InstrumentRating = true,
                PilotMedical = PilotMedicalType.ClassOne,
                PilotMedicalExpiry = new DateTime(2001, 1, 1),
                ValidBFR = true
            };
        }

        [TestMethod]
        public void CandidatePilot_ExamType_Pilot()
        {
            // Assesmble
            var candidate = new CandidatePilot();

            // Act
            var result = candidate.ExamType;
                
            // Assert
            Assert.AreEqual(ExamType.PilotExam, result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamPossible_NoCurrentExam()
        {
            // Assesmble
            var candidate = new CandidatePilot();

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamPossible_TheoryExamFailed()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.TheoryFailed
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamPossible_TheoryExamVoided()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.ExamVoided
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_NewExam()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.NewExam
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_TheoryInProgress()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.TheoryInProgress
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_TheoryPassed()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.TheoryPassed
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_PracticalComponentCompleted()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.PracticalComponentCompleted
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_EmailInProgress()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.EmailInProgress
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_SendingEmailFailed()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.SendingEmailFailed
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CandidatePilot_NewExamNotPossible_ExamCompleted()
        {
            // Assesmble
            var candidate = new CandidatePilot();
            candidate.ExamPilots = new List<ExamPilot>
                {
                    new ExamPilot
                        {
                            ExamStatus = ExamStatus.ExamCompleted
                        }
                };

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.IsFalse(result);
        }
    }
}
