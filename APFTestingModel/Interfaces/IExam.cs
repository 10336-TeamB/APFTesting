using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes exam fields
    /// </summary>
    public interface IExam
    {
        /// <summary>
        /// Id of the exam
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// Current status of the exam
        /// </summary>
        ExamStatus ExamStatus { get; }
    }
}
