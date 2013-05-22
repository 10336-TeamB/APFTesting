using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingUI.Models.CompletedExam;

namespace APFTestingUI.Controllers
{
    public class CompletedExamController : BaseController
    {
        public CompletedExamController(IFacade facade) : base(facade) { }

        public ActionResult Index(Guid CandidateId, Guid examId, ExamType examType)
        {
            return View();
        }

        //Probably wont need this if we call the subtypes directly
        public ActionResult ViewExamExamResults(Guid candidateId, Guid examId, ExamType examType)
        {
            switch (examType)
            {
                case ExamType.PilotExam:
                    return RedirectToAction("ViewPilotExamResults", new { candaidateId = candidateId, examId = examId });
                case ExamType.PackerExam:
                    return RedirectToAction("ViewPackerExamResults", new { candaidateId = candidateId, examId = examId });
                default:
                    throw new Exception("Invalid Exam Type");
            }
        }

        public ActionResult ViewPilotExamResults(Guid candidateId, Guid examId)
        {
            var pilot = _facade.FetchPilot(candidateId);
            var exam = _facade.FetchExam(examId, ExamType.PilotExam);
            var theoryComponentResult = _facade.FetchTheoryComponentResult(examId);
            var hasPassedPractical = _facade.HasPassedPractical(examId, ExamType.PilotExam);
            var model = new ExamDetailsPilot(pilot, exam, theoryComponentResult, hasPassedPractical);
            return View(model);
        }

        public ActionResult ViewPackerExamResults(Guid candidateId, Guid examId)
        {
            var packer = _facade.FetchPacker(candidateId);
            var exam = _facade.FetchExam(examId, ExamType.PackerExam);
            var theoryComponentResult = _facade.FetchTheoryComponentResult(examId);
            var hasPassedPractical = _facade.HasPassedPractical(examId, ExamType.PackerExam);
            var model = new ExamDetailsPacker(packer, exam, theoryComponentResult, hasPassedPractical);
            return View(model);
        }

        public ActionResult SubmitPilotExamResults(Guid examId)
        {
            _facade.FinaliseExam(examId, ExamType.PilotExam);
            return RedirectToAction("Index", "Examiner");
        }

        public ActionResult SubmitPackerExamResults(Guid examId)
        {
            _facade.FinaliseExam(examId, ExamType.PackerExam);
            return RedirectToAction("Index", "Examiner");
        }

    }
}
