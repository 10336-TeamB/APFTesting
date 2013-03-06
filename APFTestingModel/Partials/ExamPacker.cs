using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPacker : Exam
    {
        public ExamPacker(Guid examinerId, Guid candidateId, TheoryComponentPacker theoryComponentPacker, PracticalComponentPacker practicalComponentPacker)
            : base(examinerId, candidateId)
        {
            TheoryComponent = theoryComponentPacker;
            PracticalComponent = practicalComponentPacker;
        }
    }
}
