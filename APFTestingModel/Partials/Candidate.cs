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
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        // Hardcoded values to allow facade to work with UI.
        public string FirstName
        {
            get { return "Larry"; }
        }

        // Hardcoded values to allow facade to work with UI.
        public string LastName
        {
            get { return "Johns"; }
        }

        // Hardcoded values to allow facade to work with UI.
        public IExam LatestExam
        {
            get { return new ExamPilot { Id = Guid.NewGuid(), CandidateId = Id, ExamStatusId = 1 }; }
        }
    }
}
