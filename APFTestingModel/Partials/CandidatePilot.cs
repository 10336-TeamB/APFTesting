using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class CandidatePilot : ICandidate, ICandidatePilot
    {
        public CandidatePilot(CandidatePilotDetails details, Guid createdBy)
        {
            Edit(details);
            CreatedBy = createdBy;
        }

        public void Edit(CandidatePilotDetails details)
        {
            FirstName = details.FirstName;
            LastName = details.LastName;
            DateOfBirth = details.DateOfBirth;
            Address = new Address(details.Address1, details.Address2, details.Suburb, details.State, details.Postcode);
            ARN = details.ARN;
            PhoneNumber = details.Phone;
            MobileNumber = details.Mobile;
            Email = details.Email;
            PilotLicenceType = details.PilotLicenceType;
            InstrumentRating = details.InstrumentRating;
            PilotMedicalType = details.PilotMedical;
            PilotMedicalExpiryDate = details.PilotMedicalExpiry;
            ValidBFR = details.ValidBFR;
        }

        IAddress ICandidatePilot.Address
        {
            get { return Address; }
        }

        // Hardcoded values to allow facade to work with UI.
        public Exam LatestExam
        {
            //HACK - returning static exam
            get
            {
                //return null;
                Exam exam = ExamPilots.OrderBy(e => e.CreatedDate).LastOrDefault();

                return exam;
            }
        }

        IExam ICandidate.LatestExam
        {
            get { return LatestExam; }
        }

        public override Guid LatestExamId
        {
            get
            {
                var latestExam = LatestExam;
                if (latestExam != null)
                {
                    return latestExam.Id;
                }
                else
                {
                    return Guid.Empty;
                }

            }
        }

        //REFACTORED
        public ExamStatus LatestExamStatus
        {
            get
            {
                var latestExam = LatestExam;
                if (latestExam == null)
                {
                    return ExamStatus.NoExam;
                }
                return (ExamStatus)latestExam.ExamStatus;
            }
        }

        //REFACTORED
        public override bool NewExamPossible
        {
            get
            {
                var latestExamStatus = LatestExamStatus; //Prevents the querying of database for each condition below
                return latestExamStatus == ExamStatus.NoExam || latestExamStatus == ExamStatus.TheoryFailed || latestExamStatus == ExamStatus.ExamVoided;
            }
        }

        public ExamType ExamType
        {
            get
            {
                return ExamType.PilotExam;
            }
        }

    }
}
