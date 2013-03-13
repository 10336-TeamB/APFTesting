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
            get { return new Guid("1cc2ffb9-ffff-ffff-ffff-ffffffffffff"); }
        }

        // Hardcoded values to allow facade to work with UI.
        public string FirstName
        {
            get { return "Paul"; }
        }

        // Hardcoded values to allow facade to work with UI.
        public string LastName
        {
            get { return "Ilett"; }
        }

        // Hardcoded values to allow facade to work with UI.
        public IExam ILatestExam
        {
            get
            {
                return LatestExam;
            }

        }
        
        public Exam LatestExam
        {
            //HACK - returning static exam
            get { return new ExamPilot { Id = new Guid("1cc2ffb9-4a89-4800-9505-eb8caaaf6d59"), CandidateId = Id, ExamStatusId = 1, ExamStatus = ExamStatus.ExamCreated }; }
            //get { return null; }
            
        }


        public ExamStatus LatestExamStatus
        {
            get 
            {
                if (LatestExam == null)
                {
                    return ExamStatus.NoExamCreated;
                }
                return LatestExam.ExamStatus;
                
            }
        }
    }
}
