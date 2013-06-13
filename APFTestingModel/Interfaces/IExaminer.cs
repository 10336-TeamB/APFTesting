using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    /// <summary>
    /// Interface that exposes examiner fields
    /// </summary>
    public interface IExaminer
    {
        /// <summary>
        /// Id of the examiner
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// First Name of the examiner
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Last Name of the examiner
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// APF Number of the examiner
        /// </summary>
        string APFNumber { get; }
        /// <summary>
        /// User Id of the examiner
        /// </summary>
        int UserId { get; }
        /// <summary>
        /// UserName of the examiner
        /// </summary>
        string Username { get; }
        /// <summary>
        /// Is examiner active
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// List of examiner authority
        /// </summary>
        IEnumerable<IExaminerAuthority> ExaminerAuthorities { get; }
    }
}
