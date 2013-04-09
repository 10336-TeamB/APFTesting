using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface ICandidatePilot
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }
        IAddress Address { get; }
        string ARN { get; }
        string PhoneNumber { get; }
        string MobileNumber { get; }
        string Email { get; }
        PilotLicenceType PilotLicenceType { get; }
        bool InstrumentRating { get; }
        PilotMedicalType PilotMedicalType { get; }
        DateTime PilotMedicalExpiryDate { get; }
        bool ValidBFR { get; }
        Guid CreatedBy { get; }
    }
}
