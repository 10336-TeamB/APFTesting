﻿using System;
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
                examDetails.Add(new KeyValuePair<string, string>("D.O.B.", CandidatePilot.DateOfBirth.ToString()));
                examDetails.Add(new KeyValuePair<string, string>("ARN", CandidatePilot.ARN));
                examDetails.Add(new KeyValuePair<string, string>("Phone Number", CandidatePilot.PhoneNumber));
                examDetails.Add(new KeyValuePair<string, string>("Mobile Number", CandidatePilot.MobileNumber));
                examDetails.Add(new KeyValuePair<string, string>("Address 1", CandidatePilot.Address.Address1));
                examDetails.Add(new KeyValuePair<string, string>("Address 2", CandidatePilot.Address.Address2));
                examDetails.Add(new KeyValuePair<string, string>("Suburb", CandidatePilot.Address.Suburb));
                examDetails.Add(new KeyValuePair<string, string>("State", CandidatePilot.Address.State));
                examDetails.Add(new KeyValuePair<string, string>("Email", CandidatePilot.Email));
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
                examDetails.Add(new KeyValuePair<string, string>("Pilot Medical Expiry Date", CandidatePilot.PilotMedicalExpiryDate.ToString()));

                examDetails.Add(new KeyValuePair<string, string>("Score", String.Format("{0}/{1} ({2}%) -- Pass", TheoryComponent.NumberOfCorrectlyAnsweredQuestions, TheoryComponent.NumberOfQuestions, TheoryComponent.Score * 100)));
                
                EmailServiceReference.EmailDataContract data = new EmailServiceReference.EmailDataContract();

                data.Exam = examDetails.ToArray();
                data.ExamType = (int)ExamType.PackerExam;
                data.Body = String.Format("Please find the result for {0} {1} attached.", CandidatePilot.FirstName, CandidatePilot.LastName);
                data.Subject = "New packer exam";
                data.ExamId = Id;

                EmailServiceCallback emailCallback = new EmailServiceCallback();
                emailCallback.CallEmailService(data);
                ExamStatus = ExamStatus.EmailInProgress;
            };
            _examState.FinaliseExam(a);
        }

    }
}
