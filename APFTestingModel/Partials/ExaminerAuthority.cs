using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExaminerAuthority : IExaminerAuthority
    {
        public ExaminerAuthority() { }

        public ExaminerAuthority(Guid examinerId, ExamType examType)
        {
            ExaminerId = examinerId;
            ExamType = examType;
        }
    }
}
