using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APFTestingUI.Models.Examiner
{
    public class Index
    {
        public Index(IEnumerable<ICandidate> candidates, IExaminer examiner)
        {
            ExaminerId = examiner.Id;
            assignAuthority(examiner.ExaminerAuthorities);
            //Maybe change this to status to ExamComplete if we are not showing pending results
            var allCandidates = candidates.Select(c => new CandidateDisplayItem(c)).Where(c => c.LatestExamStatus != ExamStatus.ExamCompleted).ToList();

            //var allCandidates = candidates.Select(c => new CandidateDisplayItem(c)).ToList();

            PilotCandidates = allCandidates.Where(c => c.ExamType.Equals("PilotExam")).ToList();
            PackerCandidates = allCandidates.Where(c => c.ExamType.Equals("PackerExam")).ToList();
        }

        public IEnumerable<CandidateDisplayItem> PilotCandidates { get; set; }
        public IEnumerable<CandidateDisplayItem> PackerCandidates { get; set; }
        public Guid ExaminerId { get; set; }
        public bool PilotAuthorised { get; set; }
        public bool PackerAuthorised { get; set; }
        
        private void assignAuthority(IEnumerable<IExaminerAuthority> examinerAuthority)
        {
            foreach (var a in examinerAuthority)
            {
                if (a.ExamType == ExamType.PilotExam)
                {
                    PilotAuthorised = true;
                }
                else if (a.ExamType == ExamType.PackerExam)
                {
                    PackerAuthorised = true;
                }
            }
        }
    }
}