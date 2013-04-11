using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class ExamPilot
    {
        #region Constructors

        public ExamPilot() { }

        public ExamPilot(Guid examinerId, Guid candidateId, TheoryComponentPilot theoryComponentPilot, PracticalComponentPilot practicalComponentPilot)
            : base(examinerId)
        {
            CandidateId = candidateId;
            TheoryComponent = theoryComponentPilot;
            PracticalComponentPilot = practicalComponentPilot;
        }

        #endregion

        public ICollection<SelectedAssessmentTask> SelectedAssessmentTasks
        {
            get
            {
                return PracticalComponentPilot.SelectedAssessmentTasks;
            }
        }

        public override bool PracticalComponentIsCompetent
        {
            get
            {
                return PracticalComponentPilot.IsCompetent;
            }
        }

    }
}
