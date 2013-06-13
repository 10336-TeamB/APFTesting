using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface which exposes fields for packer candidate details
    /// </summary>
    public interface ICandidatePacker
    {
        /// <summary>
        /// Id of the packer candidate
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// First name of the packer candidate
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Last name of the packer candidate
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Mobile number of the packer candidate
        /// </summary>
        string MobileNumber { get; }
        /// <summary>
        /// APF number of the packer candidate
        /// </summary>
        string APFNumber { get; }
    }
}
