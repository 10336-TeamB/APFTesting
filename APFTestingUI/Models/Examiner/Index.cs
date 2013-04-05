using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Examiner
{
    public class Index
    {
        public Index(IEnumerable<ICandidate> candidates, Guid examinerId, List<ExamType> examinerAuthority)
        {
            ExaminerId = examinerId;
            assignAuthority(examinerAuthority);
            Candidates = candidates.Select(c => new CandidateDisplayItem(c));
        }

        public IEnumerable<CandidateDisplayItem> Candidates { get; set; }
        public Guid ExaminerId { get; set; }
        public bool PilotAuthorised { get; set; }
        public bool PackerAuthorised { get; set; }
        
        private void assignAuthority(List<ExamType> examinerAuthority)
        {
            foreach (var a in examinerAuthority)
            {
                if (a == ExamType.PilotExam)
                {
                    PilotAuthorised = true;
                }
                else if (a == ExamType.PackerExam)
                {
                    PackerAuthorised = true;
                }
            }
        }
    }
}