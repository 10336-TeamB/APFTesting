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
            Action a = delegate
            {
                List<KeyValuePair<string, string>> examDetails = new List<KeyValuePair<string, string>>();
                examDetails.Add(new KeyValuePair<string, string>("Name", String.Format("{0} {1}", CandidatePilot.FirstName, CandidatePilot.LastName)));
                if (CandidatePilot.DateOfBirth != null) examDetails.Add(new KeyValuePair<string, string>("D.O.B.", CandidatePilot.DateOfBirth.ToShortDateString()));
                if (CandidatePilot.ARN != null) examDetails.Add(new KeyValuePair<string, string>("ARN", CandidatePilot.ARN));
                if (CandidatePilot.PhoneNumber != null) examDetails.Add(new KeyValuePair<string, string>("Phone Number", CandidatePilot.PhoneNumber));
                if (CandidatePilot.MobileNumber != null) examDetails.Add(new KeyValuePair<string, string>("Mobile Number", CandidatePilot.MobileNumber));
                if (CandidatePilot.Address.Address1 != null) examDetails.Add(new KeyValuePair<string, string>("Address 1", CandidatePilot.Address.Address1));
                if (CandidatePilot.Address.Address2 != null) examDetails.Add(new KeyValuePair<string, string>("Address 2", CandidatePilot.Address.Address2));
                if (CandidatePilot.Address.Suburb != null) examDetails.Add(new KeyValuePair<string, string>("Suburb", CandidatePilot.Address.Suburb));
                if (CandidatePilot.Address.State != null) examDetails.Add(new KeyValuePair<string, string>("State", CandidatePilot.Address.State));
                if (CandidatePilot.Email != null) examDetails.Add(new KeyValuePair<string, string>("Email", CandidatePilot.Email));
                switch (CandidatePilot.PilotLicenceType)
                {
                    case PilotLicenceType.ATPL:
                        examDetails.Add(new KeyValuePair<string, string>("Pilot License Type", "ATPL"));
                        break;
                    case PilotLicenceType.CPL:
                        examDetails.Add(new KeyValuePair<string, string>("Pilot License Type", "CPL"));
                        break;
                    case PilotLicenceType.PPL:
                        examDetails.Add(new KeyValuePair<string, string>("Pilot License Type", "PPL"));
                        break;
                }
                examDetails.Add(new KeyValuePair<string, string>("Instrument Rating", (CandidatePilot.InstrumentRating) ? "Yes" : "No"));
                examDetails.Add(new KeyValuePair<string, string>("Valid BFR", (CandidatePilot.ValidBFR) ? "Yes" : "No"));
                switch (CandidatePilot.PilotMedicalType)
                {
                    case PilotMedicalType.ClassOne:
                        examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Type", "Class One"));
                        break;
                    case PilotMedicalType.ClassTwo:
                        examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Type", "Class Two"));
                        break;
                }
                if (CandidatePilot.PilotMedicalExpiryDate != null) examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Expiry Date", CandidatePilot.PilotMedicalExpiryDate.ToShortDateString()));

                examDetails.Add(new KeyValuePair<string, string>("Score", String.Format("{0}/{1} ({2}%) -- Pass", TheoryComponent.NumberOfCorrectlyAnsweredQuestions, TheoryComponent.NumberOfQuestions, TheoryComponent.Score * 100)));
                
                EmailServiceReference.EmailDataContract data = new EmailServiceReference.EmailDataContract();

                data.Exam = examDetails.ToArray();
                data.ExamType = (int)ExamType.PilotExam;
                data.Body = String.Format("Please find the result for {0} {1} attached.", CandidatePilot.FirstName, CandidatePilot.LastName);
                data.Subject = "New pilot exam";
                data.ExamId = Id;
                data.ExaminerNumber = Examiner.APFNumber;

                ExamStatus = ExamStatus.EmailInProgress;
                EmailServiceCallback emailCallback = new EmailServiceCallback();
                emailCallback.CallEmailService(data);
            };
            _examState.FinaliseExam(a);
        }

    }
}
