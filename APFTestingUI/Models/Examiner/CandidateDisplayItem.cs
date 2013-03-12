﻿using APFTestingModel;
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
            if (candidate.ILatestExam == null)
            {
                LatestExamId = Guid.Empty;
            }
            else
            {
                LatestExamId = candidate.ILatestExam.Id;
            }
            
            //LatestExamStatus = candidate.LatestExamStatus;
        }
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid LatestExamId { get; set; }
        public ExamStatus LatestExamStatus { get; set; }
        public bool TheoryComponentInProgress
        {
            get
            {
                return LatestExamStatus == ExamStatus.TheoryComponentInProgress && LatestExamStatus < ExamStatus.TheoryComponentCompleted;
            }
        }
        public bool TheoryComponentCompleted
        {
            get
            {
                return LatestExamStatus >= ExamStatus.TheoryComponentCompleted;
            }
        }

        //public bool NoExam
        //{
        //    get
        //    {
        //        return LatestExamId == Guid.Empty;
        //    }
        //}
        //public bool TheoryComponentCreated
        //{
        //    get
        //    {
        //        return LatestExamStatus == ExamStatus.ExamCreated;
        //    }
        //}
        //public bool TheoryComponentInProgress
        //{
        //    get
        //    {
        //        return LatestExamStatus == ExamStatus.TheoryComponentInProgress;
        //    }
        //}
        //public bool TheoryComponentCompleted
        //{
        //    get
        //    {
        //        return LatestExamStatus == ExamStatus.TheoryComponentFailed || LatestExamStatus == ExamStatus.TheoryComponentCompleted;
        //    }
        //}

        
    }

}