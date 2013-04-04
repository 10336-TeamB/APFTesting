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
        }
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid LatestExamId { get; set; }
        public ExamStatusEnum LatestExamStatus { get; set; }

        #region Exam Status Properties
        
        public bool ExamNullOrCreated
        {
            get
            {
                return LatestExamStatus <= ExamStatusEnum.NewExam;
            }
        }

        public bool TheoryComponentInProgress
        {
            get
            {
                return LatestExamStatus == ExamStatusEnum.TheoryInProgress;
            }
        }

        public bool TheoryComponentFailed
        {
            get
            {
                return LatestExamStatus == ExamStatusEnum.TheoryFailed;
            }
        }

        #endregion
    }
}