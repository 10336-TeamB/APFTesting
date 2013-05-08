using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    public interface IExaminer
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string APFNumber { get; }
        int UserId { get; }
        string Username { get; }
        IEnumerable<IExaminerAuthority> ExaminerAuthorities { get; }
    }
}
