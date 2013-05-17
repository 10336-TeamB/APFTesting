using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingModel.EmailServiceReference;

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
            Action a = delegate
            {
                List<KeyValuePair<string, string>> examDetails = new List<KeyValuePair<string, string>>();

                examDetails.Add(new KeyValuePair<string, string>("Name", String.Format("{0} {1}", CandidatePilot.FirstName, CandidatePilot.LastName)));
                examDetails.Add(new KeyValuePair<string, string>("Mobile Number", CandidatePilot.MobileNumber));
                examDetails.Add(new KeyValuePair<string, string>("Score", String.Format("{0}/{1} ({2}%) -- Pass", TheoryComponent.NumberOfCorrectlyAnsweredQuestions, TheoryComponent.NumberOfQuestions, TheoryComponent.Score * 100)));
                                
                EmailDataContract data = new EmailDataContract();

                data.Exam = examDetails.ToArray();
                data.ExamType = (int)ExamType.PackerExam;
                data.Body = String.Format("Please find the result for {0} {1} attached.", CandidatePilot.FirstName, CandidatePilot.LastName);
                data.Subject = "New packer exam";

                EmailServiceOperationClient client = new EmailServiceOperationClient();
                client.SendEmail(data);

                ExamStatus = ExamStatus.ExamCompleted;
            };
            _examState.FinaliseExam(a);
        }

    }
}
