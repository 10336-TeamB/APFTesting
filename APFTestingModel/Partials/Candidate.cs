using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class Candidate : ICandidate
    {
        // HACK - Hardcoded values to allow facade to work with UI.
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        // HACK - Hardcoded values to allow facade to work with UI.
        public string FirstName
        {
            get { return "Larry"; }
        }

        // HACK - Hardcoded values to allow facade to work with UI.
        public string LastName
        {
            get { return "Johns"; }
        }

        // HACK - Hardcoded values to allow facade to work with UI.
        public IExam LatestExam
        {
            get { return new ExamPilot { Id = Guid.Parse("c25304dc-1069-47c6-97f8-b385305a2531"), CandidateId = Id, ExamStatusId = 1 }; }
        }
    }
}
