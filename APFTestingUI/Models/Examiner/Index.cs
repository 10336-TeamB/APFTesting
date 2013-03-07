using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Examiner
{
    public class Index
    {
        public Index(IEnumerable<ICandidate> candidates)
        {
            Candidates = candidates.Select(c => new CandidateDisplayItem(c));
        }


        public IEnumerable<CandidateDisplayItem> Candidates { get; set; }
    }
}