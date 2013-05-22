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

        public void SubmitPilotPracticalResults(List<PilotPracticalResult> results)
        {
            Action a = delegate
            {
                foreach (var r in results)
                {
                    try
                    {
                        SelectedAssessmentTasks.First(t => t.Id == r.Id).RecordResult(r);
                    }
                    catch (ArgumentNullException)
                    {
                        //TODO: Log exception
                        throw new BusinessRuleException("Error while recording results. The requested result could not be found");
                    }
                }
            };
            _examState.SubmitPilotPracticalResults(a);
        }

        public override void FinaliseExam()
        {
            
        }

    }
}
