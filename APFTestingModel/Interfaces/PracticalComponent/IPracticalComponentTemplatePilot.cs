using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes pilot practical component template
    /// </summary>
    public interface IPracticalComponentTemplatePilot
    {
        /// <summary>
        /// Id of the practical component template
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// If true, the template is currently in use
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// List of all the assessment task associated with the template
        /// </summary>
        IEnumerable<IAssessmentTaskPilot> Tasks { get; }
        /// <summary>
        /// If true, the template can be edited or deleted
        /// </summary>
        bool AllowEditOrDelete { get; }
    }
}