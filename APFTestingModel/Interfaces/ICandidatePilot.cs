using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface which exposes fields for pilot candidate details
    /// </summary>
    public interface ICandidatePilot
    {
        /// <summary>
        /// Id of the pilot candidate
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// First name of the pilot candidate
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Last name of the pilot candidate
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Date of birth of the pilot candidate
        /// </summary>
        DateTime DateOfBirth { get; }
        /// <summary>
        /// Address of the pilot candidate
        /// </summary>
        IAddress Address { get; }
        /// <summary>
        /// ARN of the pilot candidate
        /// </summary>
        string ARN { get; }
        /// <summary>
        /// Phone Number of the pilot candidate
        /// </summary>
        string PhoneNumber { get; }
        /// <summary>
        /// Mobile Number of the pilot candidate
        /// </summary>
        string MobileNumber { get; }
        /// <summary>
        /// Email of the pilot candidate
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Licence Type of the pilot candidate
        /// </summary>
        PilotLicenceType PilotLicenceType { get; }
        /// <summary>
        /// Instrument Rating of the pilot candidate
        /// </summary>
        bool InstrumentRating { get; }
        /// <summary>
        /// Medical Type of the pilot candidate
        /// </summary>
        PilotMedicalType PilotMedicalType { get; }
        /// <summary>
        /// Medical Expiry Date of the pilot candidate
        /// </summary>
        DateTime PilotMedicalExpiryDate { get; }
        /// <summary>
        /// Valid BFR of the pilot candidate
        /// </summary>
        bool ValidBFR { get; }
        /// <summary>
        /// Id of the examiner who created the pilot candidate
        /// </summary>
        Guid CreatedBy { get; }
    }
}
