using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface which exposes fields for candidate details
    /// </summary>
    public interface ICandidate
    {
        /// <summary>
        /// Id of the candidate
        /// </summary>
        Guid Id { get; }
        //First name of the candidate
        string FirstName { get; }
        /// <summary>
        /// Last name of the candidate
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Latest exam that was taken by the candidate
        /// </summary>
        IExam LatestExam { get; }
        /// <summary>
        /// Type of the candidate
        /// </summary>
        ExamType ExamType { get; }

        /// <summary>
        /// Status of the latest exam taken by the candidate
        /// </summary>
        ExamStatus LatestExamStatus { get; }

    }
}
