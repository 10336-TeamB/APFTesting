using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes assessment task of pilot candidate
    /// </summary>
    public interface IAssessmentTaskPilot
    {
        /// <summary>
        /// Id of the assessment
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Title of the assessment
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Details of the assessment
        /// </summary>
        string Details { get; }
        /// <summary>
        /// Maximum score of the assessment
        /// </summary>
        int MaxScore { get; }
        /// <summary>
        /// Assessment task can be updated only if this field is true
        /// </summary>
        bool EnableChange { get; }
    }
}
