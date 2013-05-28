using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class CandidatePacker : ICandidate, ICandidatePacker
    {
        public CandidatePacker(CandidatePackerDetails details, Guid createdBy)
        {
            Edit(details);
            CreatedBy = createdBy;
        }

        public void Edit(CandidatePackerDetails details)
        {
            if (!Regex.IsMatch(details.APFNumber, @"^[0-9]{5,6}$"))
            {
                throw new BusinessRuleException("APF number must be 5 or 6 digits");
            }
            if (!Regex.IsMatch(details.Mobile, @"^04[0-9]{8}$"))
            {
                throw new BusinessRuleException("Mobile number must only contain numbers and conform to format 0400123123");
            }

            this.FirstName = details.FirstName;
            this.LastName = details.LastName;
            this.MobileNumber = details.Mobile;
            this.APFNumber = details.APFNumber;
        }

        public Exam LatestExam
        {
            get
            {
                return ExamPackers.OrderBy(e => e.CreatedDate).LastOrDefault();
            }
        }

        IExam ICandidate.LatestExam
        {
            get { return LatestExam; }
        }

        public override Guid LatestExamId
        {
            get
            {
                var latestExam = LatestExam;
                if (LatestExam != null)
                {
                    return latestExam.Id;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public ExamStatus LatestExamStatus
        {
            get
            {
                var latestExam = LatestExam;
                if (latestExam == null)
                {
                    return ExamStatus.NoExam;
                }
                return (ExamStatus)latestExam.ExamStatus;
            }
        }

        public override bool NewExamPossible
        {
            get
            {
                var latestExamStatus = LatestExamStatus; //Prevents the querying of database for each condition below
                return latestExamStatus == ExamStatus.NoExam || latestExamStatus == ExamStatus.TheoryFailed || latestExamStatus == ExamStatus.ExamVoided;
            }
        }

        public ExamType ExamType 
        {
            get
            {
                return ExamType.PackerExam;
            }
        }
    }
}
