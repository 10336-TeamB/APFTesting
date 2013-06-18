using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes pilot practical component
    /// </summary>
    public interface IPracticalComponentPilot
    {
        /// <summary>
        /// Id of the practical component
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Creation date of the practical component
        /// </summary>
        DateTime CreationDate { get; }
        /// <summary>
        /// If true, the pilot has successfully passed the practical component
        /// </summary>
        bool IsCompetent { get; }
        /// <summary>
        /// List of all the assessment tasks associated with the practical component
        /// </summary>
        IEnumerable<ISelectedAssessmentTask> AssessmentTasks { get; }
    }
}
