using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Examiner : IExaminer
    {
        public Examiner(ExaminerDetails examinerDetails, int userId)
        {
            EditExaminer(examinerDetails);
            UserId = userId;
            IsActive = true;
        }

        public void EditExaminer(ExaminerDetails examinerDetails)
        {
            FirstName = examinerDetails.FirstName;
            LastName = examinerDetails.LastName;
            APFNumber = examinerDetails.APFNumber;
            ExaminerAuthorities = examinerDetails.Authorities.Select(a => new ExaminerAuthority(Id, a)).ToList();
        }

        public void EditActiveStatus(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
