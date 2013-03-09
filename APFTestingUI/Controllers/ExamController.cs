using APFTestingUI.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Controllers
{
    //TODO: Add authorise attribute for an examiner
    public class ExamController : BaseController
    {
        //
        // GET: /Exam/Create

        //public ActionResult Create()
        //{

        //}

        //
        // GET: /Exam/Start/

        public ActionResult Start(Guid examId)
        {
            ViewBag.ExamId = examId;
            return View();
        }

        //
        // GET: /Exam/NextQuestion/

        public ActionResult NextQuestion(Guid examId)
        {
            // TODO - Not sure if i'm happy with examId being passed in like this. Should ITheoryQuestion know this instead? - ADAM
            var model = new QuestionDisplayItem(_facade.FetchNextQuestion(examId), examId);
            return View("DisplayQuestion", model);
        }

        //
        // GET: /Exam/PreviousQuestion/

        public ActionResult PreviousQuestion(Guid examId)
        {
            var model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(examId), examId);
            return View("DisplayQuestion", model);
        }

        //
        // GET: /Exam/Question/

        public ActionResult Question(Guid examId, int questionNumber)
        {
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber), examId);
            return View("DisplayQuestion", model);
        }


        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            // TODO: Communicate with facade to submit answer
            

            if (question.NavDirection)
            {
                return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
            }
            return RedirectToAction("NextQuestion", new { examId = question.ExamId });
        }

        [HttpGet]
        public ActionResult FetchSummary(Guid examId)
        {
            var model = new TheoryComponentSummary() { Questions = _facade.FetchTheoryComponentSummary(examId).OrderBy(q => q.QuestionIndex) };
            return View(model);
        }

        [HttpGet]
        public ActionResult FetchResult(Guid examId)
        {
            //_facade.FinaliseTheoryComponent();
            // We may need this to display what their score is as a mark/passmark
            //_facade.FetchTheoryExamFormatDetails();
            //_facade.FetchCandidateDetails();
            var model = new TheoryComponentResult(_facade.FetchTheoryComponentResult(examId));
            return View(model);
        }

    }
}
