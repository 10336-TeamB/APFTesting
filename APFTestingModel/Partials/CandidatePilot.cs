using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingModel
{
    internal partial class CandidatePilot : Person, ICandidate
    {
        // Hardcoded values to allow facade to work with UI.
        //public Guid Id
        //{
        //    get { return new Guid("1cc2ffb9-ffff-ffff-ffff-ffffffffffff"); }
        //}

        //// Hardcoded values to allow facade to work with UI.
        //public string FirstName
        //{
        //    get { return "Paul"; }
        //}

        //// Hardcoded values to allow facade to work with UI.
        //public string LastName
        //{
        //    get { return "Ilett"; }
        //}

        public CandidatePilot(CandidatePilotDetails details, Guid createdBy)
        {
            FirstName = details.FirstName;
            LastName = details.LastName;
            DateOfBirth = details.DateOfBirth;
            Address = new Address(details.Address1, details.Address2, details.Suburb, details.Postcode);
            ARN = details.ARN;
            PhoneNumber = details.Phone;
            MobileNumber = details.Mobile;
            Email = details.Email;
            PilotLicenseTypeId = details.PilotLicenceType;
            InstrumentRating = details.InstrumentRating;
            PilotMedicalTypeId = details.PilotMedical;
            PilotMedicalExpiryDate = details.PilotMedicalExpiry;
            ValidBFR = details.ValidBFR;
            CreatedBy = createdBy;
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
                    return LatestExam.Id;
                }
                else
                {
                    return Guid.Empty;
                }

            }
        }

        public ExamStatus LatestExamStatus
        {
            get
            {
                var latestExam = LatestExam;
                if (latestExam == null)
                {
                    return ExamStatus.NoExamCreated;
                }
                return latestExam.ExamStatus;
            }
        }

        public override bool NewExamPossible
        {
            get
            {
                var latestExamStatus = LatestExamStatus; //Prevents the querying of database for each condition below
                return latestExamStatus == ExamStatus.NoExamCreated || latestExamStatus == ExamStatus.TheoryComponentFailed || latestExamStatus == ExamStatus.ExamVoided;
            }
        }

    }
}
