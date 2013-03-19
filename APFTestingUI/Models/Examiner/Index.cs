using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Examiner
{
    public class Index
    {
        public Index(IEnumerable<ICandidate> candidates, Guid examinerId)
        {
            Candidates = candidates.Select(c => new CandidateDisplayItem(c));
            ExaminerId = examinerId;
        }

        public IEnumerable<CandidateDisplayItem> Candidates { get; set; }
        public Guid ExaminerId { get; set; }
    }
}