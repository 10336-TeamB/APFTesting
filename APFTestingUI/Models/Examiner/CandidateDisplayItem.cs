using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Examiner
{
    public class CandidateDisplayItem
    {
        public CandidateDisplayItem(ICandidate candidate) {
            Id = candidate.Id;
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
            if (candidate.LatestExam == null)
            {
                LatestExamId = Guid.Empty;
            }
            else
            {
                LatestExamId = candidate.LatestExam.Id;
            }
            
            LatestExamStatus = candidate.LatestExamStatus;
            ExamType = candidate.ExamType.ToString();
        }
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid LatestExamId { get; set; }
        public ExamStatus LatestExamStatus { get; set; }
        public string ExamType { get; set; }

        #region Exam Status Properties
        
        public bool ExamNullOrCreated
        {
            get
            {
                return LatestExamStatus <= ExamStatus.NewExam;
            }
        }

        public bool TheoryComponentInProgress
        {
            get
            {
                return LatestExamStatus == ExamStatus.TheoryInProgress;
            }
        }

        public bool TheoryComponentFailed
        {
            get
            {
                return LatestExamStatus == ExamStatus.TheoryFailed;
            }
        }
		public bool PracticalAvailable
		{
			get
			{
				return LatestExamStatus == ExamStatus.TheoryPassed;
			}
			
		}

        #endregion
    }
}