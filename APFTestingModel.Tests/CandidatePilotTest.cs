using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APFTestingModel.Tests
{
    [TestClass]
    public class CandidatePilotTest
    {
        [TestMethod]
        public void Candidate_EmptyCtr_AllDefault()
        {
            //Assemble
            var candidate = new CandidatePilot();

            //Assert

            Assert.AreEqual(candidate.FirstName, null);
            //TODO: Confirm all other values
        }

        [TestMethod]
        public void Candidate_Edit_AllValuesChanged()
        {
            // Assemble
            var candidate = new CandidatePilot();
            // Act

            //TODO: Edit candidate

            // Assert


            // Assert all values to equal below...
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
    }
}
