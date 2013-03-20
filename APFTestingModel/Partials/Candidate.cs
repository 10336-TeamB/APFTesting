using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Candidate : ICandidate
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

        // Hardcoded values to allow facade to work with UI.
        public Exam LatestExam
        {
            //HACK - returning static exam
            get
            {
                //return null;
                Exam exam = Exams.OrderBy(e => e.CreatedDate).LastOrDefault();
                
                return exam;
            }
        }

        IExam ICandidate.LatestExam
        {
            get { return LatestExam; }
        }

        public Guid LatestExamId
        {
            get
            {
				var latestExam = LatestExam;
				if (latestExam != null)
				{
					return LatestExam.Id;
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
                    return ExamStatus.NoExamCreated;
                }
				return latestExam.ExamStatus;
            }
        }

        public bool NewExamPossible
        {
            get
            {
				var latestExamStatus = LatestExamStatus; //Prevents the querying of database for each condition below
				return latestExamStatus == ExamStatus.NoExamCreated || latestExamStatus == ExamStatus.TheoryComponentFailed || latestExamStatus == ExamStatus.ExamVoided;
            }
        }

    }
}
