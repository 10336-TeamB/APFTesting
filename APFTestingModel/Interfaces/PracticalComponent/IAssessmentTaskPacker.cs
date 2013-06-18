using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes assessment task of packer candidate
    /// </summary>
    public interface IAssessmentTaskPacker
    {
        /// <summary>
        /// Id of assessment task
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Date of the assessment task that was taken
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Canopy type of the parachute
        /// </summary>
        string CanopyType { get; }
        /// <summary>
        /// Id of the supervisor that did the assessment
        /// </summary>
        string SupervisorId { get; }
        /// <summary>
        /// Harness Container Type of the parachute
        /// </summary>
        string HarnessContainerType { get; }
        /// <summary>
        /// Note of the assessment
        /// </summary>
        string Note { get; }
    }
}
