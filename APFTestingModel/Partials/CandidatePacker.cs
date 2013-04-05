using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class CandidatePacker : ICandidate
    {
        // Hardcoded values to allow facade to work with UI.
        //public Guid Id
        //{
        //    get { return new Guid("1cc2ffb9-ffff-ffff-ffff-ffffffffffff"); }
        //}

        //// Hardcoded values to allow facade to work with UI.
        //public string FirstName
        //{
        //    get { return "Paul"; }
        //}

        //// Hardcoded values to allow facade to work with UI.
        //public string LastName
        //{
        //    get { return "Ilett"; }
        //}

        public CandidatePacker(CandidatePackerDetails details, Guid createdBy)
        {
			//this.FirstName = details.FirstName;
			//this.LastName = details.LastName;
			//this.MobileNumber = details.Mobile;
			//this.APFNumber = details.APFNumber;
            CreatedBy = createdBy;
        }

        // Hardcoded values to allow facade to work with UI.
        public Exam LatestExam
        {
            //HACK - returning static exam
            get
            {
                //return null;
                Exam exam = ExamPackers.OrderBy(e => e.CreatedDate).LastOrDefault();

                return exam;
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
                if (latestExam != null)
                {
                    return latestExam.Id;
                }
                else
                {
                    return Guid.Empty;
                }

            }
        }

        //REFACTORED
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

        //REFACTORED
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
