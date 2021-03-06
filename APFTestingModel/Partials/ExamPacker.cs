﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APFTestingModel.EmailServiceReference;

namespace APFTestingModel
{
    internal partial class ExamPacker : Exam
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
            Action a = delegate
            {
                AssessmentTaskPacker assessment = new AssessmentTaskPacker(packerResult);
                PracticalComponentPacker.AssessmentTaskPackers.Add(assessment);
            };
            _examState.AddPracticalComponentResult(a);
        }

        public void EditPackerPracticalResult(Guid taskId, PackerPracticalResult result)
        {
            Action a = delegate
            {
                AssessmentTasks.First(t => t.Id == taskId).Edit(result);
            };
            _examState.EditPackerPracticalResult(a);
        }

        public ICollection<AssessmentTaskPacker> AssessmentTasks
        {
            get { 
                
                return PracticalComponentPacker.AssessmentTaskPackers; }
        }

        public override bool PracticalComponentIsCompetent 
        {
            get
            {
                return PracticalComponentPacker.IsCompetent;
            }
        }

        public override void FinaliseExam()
        {
            Action a = delegate
            {
                List<KeyValuePair<string, string>> examDetails = new List<KeyValuePair<string, string>>();
                examDetails.Add(new KeyValuePair<string, string>("Name", String.Format("{0} {1}", CandidatePacker.FirstName, CandidatePacker.LastName)));
                if (CandidatePacker.MobileNumber != null) examDetails.Add(new KeyValuePair<string, string>("Mobile Number", CandidatePacker.MobileNumber));
                if (CandidatePacker.APFNumber != null) examDetails.Add(new KeyValuePair<string, string>("APF Number", CandidatePacker.APFNumber));
                examDetails.Add(new KeyValuePair<string, string>("Score", String.Format("{0}/{1} ({2}%) -- Pass", TheoryComponent.NumberOfCorrectlyAnsweredQuestions, TheoryComponent.NumberOfQuestions, TheoryComponent.Score * 100)));
                
                EmailServiceReference.EmailDataContract data = new EmailServiceReference.EmailDataContract();
                
                data.Exam = examDetails.ToArray();
                data.ExamType = (int)ExamType.PackerExam;
                data.Body = String.Format("Please find the result for {0} {1} attached.", CandidatePacker.FirstName, CandidatePacker.LastName);
                data.Subject = "New packer exam";
                data.ExamId = Id;
                data.ExaminerNumber = Examiner.APFNumber;
                data.RequiredPackerPacks = PracticalComponent.NumOfRequiredAssessmentTasks;

                ExamStatus = ExamStatus.EmailInProgress;
                EmailServiceCallback emailCallback = new EmailServiceCallback();
                emailCallback.CallEmailService(data); 
            };
            _examState.FinaliseExam(a);
        }
    }
}
