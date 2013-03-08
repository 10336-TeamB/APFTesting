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
            bool isLastQuestion = false;
            var model = new QuestionDisplayItem(_facade.FetchNextQuestion(new Guid("1cc2ffb9-4a89-4800-9505-eb8caaaf6d59"), ref isLastQuestion), examId, isLastQuestion, false);
            return View("DisplayQuestion", model);
        }

        //
        // GET: /Exam/PreviousQuestion/

        public ActionResult PreviousQuestion(Guid examId)
        {
            //TODO: Fetch previous question from Model
            //Question q = _facade.FetchNextQuestion(examId);
            bool isFirstQuestion = false;
            var model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(new Guid("1cc2ffb9-4a89-4800-9505-eb8caaaf6d59"), ref isFirstQuestion), examId, false, isFirstQuestion);
            return View("DisplayQuestion", model);
        }

        //
        // GET: /Exam/Question/

        public ActionResult Question(Guid examId, int questionNumber)
        {
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(new Guid("1cc2ffb9-4a89-4800-9505-eb8caaaf6d59"), questionNumber), examId);
            return View("DisplayQuestion", model);
        }


        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            // Communicate with facade to submit answer
            

            if (question.NavDirection)
            {
                return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
            }
            return RedirectToAction("NextQuestion", new { examId = question.ExamId });
        }
    }
}
