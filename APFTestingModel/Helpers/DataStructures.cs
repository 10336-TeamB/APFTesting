using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public struct CandidatePilotDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string ARN { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public short? PilotLicenceType { get; set; }
        public bool InstrumentRating { get; set; }
        public short? PilotMedical { get; set; }
        public DateTime PilotMedicalExpiry { get; set; }
        public bool ValidBFR { get; set; }
    }

    public struct CandidatePackerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string APFNumber { get; set; }
    }

    public struct PilotPracticalResult
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
    }

    public struct PackerPracticalResult
    {
        public DateTime Date { get; set; }
        public string CanopyType { get; set; }
        public string CanopyTypeSerialNumber { get; set; }
        public string SupervisorId { get; set; }
        public string HarnessContainerType { get; set; }
        public string HarnessContainerSerialNumber { get; set; }
        public string Note { get; set; }
    }
}
