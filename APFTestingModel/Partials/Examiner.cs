using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!Regex.IsMatch(examinerDetails.APFNumber, @"^[0-9]{5,6}$"))
            {
                throw new BusinessRuleException("APF number must be 5 or 6 digits");
            }
            if (!examinerDetails.Authorities.Any())
            {
                throw new BusinessRuleException("Examiner must have at least one authority type");
            }

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

        public bool Deleteable
        {
            get { return !(CandidatePilots.Any() || CandidatePackers.Any()); }
        }

        public void Delete(deleteEntityDelegate<Examiner> delete)
        {
            if (!Deleteable)
            {
                throw new BusinessRuleException("You can not delete an examiner who has associated candidates.");
            }
            delete(this);
        }
    }
}
