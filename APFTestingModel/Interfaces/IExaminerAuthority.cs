using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes examiner authority
    /// </summary>
    public interface IExaminerAuthority
    {
        /// <summary>
        /// Type of exam that examiner can supervise
        /// </summary>
        ExamType ExamType { get; }
    }
}
