using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes theory component format
    /// </summary>
    public interface ITheoryComponentFormat
    {
        /// <summary>
        /// Id of the theory component format
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Number of question in theory component
        /// </summary>
        int NumberOfQuestions { get; }
        /// <summary>
        /// Passmark of the theory exam
        /// </summary>
        int PassMark { get; }
        /// <summary>
        /// If true, the theory component format is currently in use
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Time limit for the theory component (currently unused by the system)
        /// </summary>
        int TimeLimit { get; }
        /// <summary>
        /// If true, the theory component can be edited or deleted
        /// </summary>
        bool AllowEditOrDelete { get; }
    }
}
