using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes selected assessment task
    /// </summary>
    public interface ISelectedAssessmentTask
    {
        /// <summary>
        /// Id of the selected assessment task
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// Comment on the assessment task
        /// </summary>
        string Comment { get; set; }
        /// <summary>
        /// Score achieved
        /// </summary>
        Nullable<int> Score { get; set; }
        /// <summary>
        /// Title of the assement task
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Details of the assessment task
        /// </summary>
        string Details { get; }
        /// <summary>
        /// Maximum score of the assessment task
        /// </summary>
        int MaxScore { get; }
    }
}
