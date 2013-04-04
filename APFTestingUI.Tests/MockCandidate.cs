using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingUI.Tests
{
    internal class MockCandidate : ICandidate
    {
        public Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public string FirstName
        {
            get { return "CandidateFirstName"; }
        }

        public string LastName
        {
            get { return "CandidateLastName"; }
        }

        public IExam LatestExam
        {
            get { return null; }
        }

        public ExamStatusEnum LatestExamStatus
        {
            get { return ExamStatusEnum.NoExam; }
        }
    }
}
