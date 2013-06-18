using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes practical component of packer
    /// </summary>
    public interface IPracticalComponentPacker
    {
        /// <summary>
        /// Id of the practical component
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Creation date od the practical component
        /// </summary>
        DateTime CreationDate { get; }
        /// <summary>
        /// If true, packer has successfully passed the practical component
        /// </summary>
        bool IsCompetent { get; }
        /// <summary>
        /// Total number of required assessment task to pass the assessment
        /// </summary>
        int NumOfRequiredAssessmentTasks { get; }
        /// <summary>
        /// List of all the assessment tasks associated with the practical component
        /// </summary>
        IEnumerable<IAssessmentTaskPacker> AssessmentTasks { get; }
    }
}
