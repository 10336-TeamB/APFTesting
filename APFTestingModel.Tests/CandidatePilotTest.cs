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
            Assert.AreEqual(candidate.FirstName, null);
            Assert.AreEqual(candidate.LastName, null);
            Assert.AreEqual(candidate.DateOfBirth, DateTime.MinValue);
            Assert.AreEqual(candidate.Address, null);
            Assert.AreEqual(candidate.ARN, null);
            Assert.AreEqual(candidate.PhoneNumber, null);
            Assert.AreEqual(candidate.MobileNumber, null);
            Assert.AreEqual(candidate.Email, null);
            Assert.AreEqual(candidate.PilotLicenceType, (PilotLicenceType)0);
            Assert.AreEqual(candidate.InstrumentRating, false);
            Assert.AreEqual(candidate.PilotMedicalType, (PilotMedicalType)0);
            Assert.AreEqual(candidate.PilotMedicalExpiryDate, DateTime.MinValue);
            Assert.AreEqual(candidate.ValidBFR, false);
        }

        [TestMethod]
        public void CandidatePilot_CtrWithDetails_ValuesCorrectlyAssigned()
        {
            // Assemble
            var guid = Guid.NewGuid();
            var candidate = new CandidatePilot(createPilotDetails(), guid);

            // Assert
            Assert.AreEqual(candidate.CreatedBy, guid);
            Assert.AreEqual(candidate.FirstName, "Adam");
            Assert.AreEqual(candidate.LastName, "Smith");
            Assert.AreEqual(candidate.DateOfBirth, new DateTime(1950, 1, 1));
            Assert.AreEqual(candidate.Address.Address1, "Unit 1");
            Assert.AreEqual(candidate.Address.Address2, "1 Test Drive");
            Assert.AreEqual(candidate.Address.Suburb, "Aardvark Central");
            Assert.AreEqual(candidate.Address.State, "AAA");
            Assert.AreEqual(candidate.Address.Postcode, "0001");
            Assert.AreEqual(candidate.ARN, "000001");
            Assert.AreEqual(candidate.PhoneNumber, "0000000001");
            Assert.AreEqual(candidate.MobileNumber, "0400000001");
            Assert.AreEqual(candidate.Email, "a@a.com");
            Assert.AreEqual(candidate.PilotLicenceType, PilotLicenceType.CPL);
            Assert.AreEqual(candidate.InstrumentRating, true);
            Assert.AreEqual(candidate.PilotMedicalType, PilotMedicalType.ClassOne);
            Assert.AreEqual(candidate.PilotMedicalExpiryDate, new DateTime(2001, 1, 1));
            Assert.AreEqual(candidate.ValidBFR, true);
        }

        [TestMethod]
        public void CandidatePilot_Edit_AllValuesChanged()
        {
            // Assemble
            var candidate = new CandidatePilot();
            // Act

            candidate.Edit(createPilotDetails());

            // Assert
            Assert.AreEqual(candidate.FirstName, "Adam");
            Assert.AreEqual(candidate.LastName, "Smith");
            Assert.AreEqual(candidate.DateOfBirth, new DateTime(1950, 1, 1));
            Assert.AreEqual(candidate.Address.Address1, "Unit 1");
            Assert.AreEqual(candidate.Address.Address2, "1 Test Drive");
            Assert.AreEqual(candidate.Address.Suburb, "Aardvark Central");
            Assert.AreEqual(candidate.Address.State, "AAA");
            Assert.AreEqual(candidate.Address.Postcode, "0001");
            Assert.AreEqual(candidate.ARN, "000001");
            Assert.AreEqual(candidate.PhoneNumber, "0000000001");
            Assert.AreEqual(candidate.MobileNumber, "0400000001");
            Assert.AreEqual(candidate.Email, "a@a.com");
            Assert.AreEqual(candidate.PilotLicenceType, PilotLicenceType.CPL);
            Assert.AreEqual(candidate.InstrumentRating, true);
            Assert.AreEqual(candidate.PilotMedicalType, PilotMedicalType.ClassOne);
            Assert.AreEqual(candidate.PilotMedicalExpiryDate, new DateTime(2001, 1, 1));
            Assert.AreEqual(candidate.ValidBFR, true);
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
            Assert.AreEqual(result, ExamType.PilotExam);
        }

        [TestMethod]
        public void CandidatePilot_NewExamPossible_NoCurrentExam()
        {
            // Assesmble
            var candidate = new CandidatePilot();

            // Act
            var result = candidate.NewExamPossible;

            // Assert
            Assert.AreEqual(result, true);
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
            Assert.AreEqual(result, true);
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
            Assert.AreEqual(result, true);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
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
            Assert.AreEqual(result, false);
        }
    }
}
