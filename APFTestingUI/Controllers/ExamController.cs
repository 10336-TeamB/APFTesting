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
  
            return View("DisplayQuestion");
        }

        //
        // GET: /Exam/PreviousQuestion/

        public ActionResult PreviousQuestion()
        {
            //TODO: Fetch previous question from Model
            //Question q = _facade.FetchNextQuestion(examId);
            return View("DisplayQuestion");
        }

        //
        // GET: /Exam/Question/

        public ActionResult Question(Guid examId, int questionNumber)
        {
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber));
            return View("DisplayQuestion");
        }
    }
}
