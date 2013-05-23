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

        public string Username
        {
            get
            {
                return User.UserName;
            }

        }

        IEnumerable<IExaminerAuthority> IExaminer.ExaminerAuthorities
        {
            get
            {
                return ExaminerAuthorities;
            }
        }

        public void Delete(deleteEntityDelegate<Examiner> delete)
        {
            if (CandidatePilots.Any() || CandidatePackers.Any())
            {
                throw new BusinessRuleException("You can not delete an examiner who has associated candidates.");
            }
            delete(this);
        }
    }
}
