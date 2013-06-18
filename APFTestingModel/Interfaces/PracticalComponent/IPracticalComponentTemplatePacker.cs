using System;
using System.Collections.Generic;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes packer practical component template
    /// </summary>
    public interface IPracticalComponentTemplatePacker
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
        /// Number of assessment tasks required to successfully pass the assessment
        /// </summary>
        int NumOfRequiredAssessmentTasks { get; }
        /// <summary>
        /// If true, the template can be edited or deleted
        /// </summary>
        bool AllowEditOrDelete { get; }
    }
}