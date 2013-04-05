using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPacker
    {
        #region Constructors

        public ExamPacker() { }

        public ExamPacker(Guid examinerId, Guid candidateId, TheoryComponentPacker theoryComponentPacker, PracticalComponentPacker practicalComponentPacker)
            : base(examinerId)
        {
            CandidateId = candidateId;
            TheoryComponent = theoryComponentPacker;
            PracticalComponentPacker = practicalComponentPacker;
        }

        #endregion

        public IPracticalComponentPacker PracticalComponent
        {
            get { return PracticalComponentPacker; }
        }

        public void AddPracticalComponentResult(PackerPracticalResult packerResult)
        {
            AssessmentTaskPacker assessment = new AssessmentTaskPacker(packerResult);

            PracticalComponentPacker.AssessmentTaskPackers.Add(assessment);
        }

        public ICollection<AssessmentTaskPacker> AssessmentTasks
        {
            get { return PracticalComponentPacker.AssessmentTaskPackers; }
        }
    }
}
