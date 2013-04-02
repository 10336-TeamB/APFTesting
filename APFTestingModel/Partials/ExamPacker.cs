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
            base.PracticalComponent = practicalComponentPacker;
        }

        #endregion

        public new IPracticalComponentPacker PracticalComponent
        {
            get { return base.PracticalComponent as PracticalComponentPacker; }
        }
    }
}
