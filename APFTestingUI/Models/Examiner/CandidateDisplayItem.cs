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
            LatestExamId = candidate.LatestExam.Id;
        }
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid LatestExamId { get; set; }
    }
}