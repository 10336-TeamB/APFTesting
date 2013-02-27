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
        // GET: /Exam/Start/

        public ActionResult Start()
        {
            //TODO: relate start page to a specifc exam
            //TODO: Based on Exam use exam format information in view
            //TODO: Handle exception of unknown Guid
            return View();
        }

        //
        // GET: /Exam/NextQuestion/

        public ActionResult NextQuestion()
        {
            //TODO: Fetch next question from Model
            //var model = new TheoryQuestion(facade.FetchNextQuestion(examId));
            var model = new TheoryQuestion();
            return View("DisplayQuestion", model);
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

        public ActionResult Question(int questionNumber)
        {
            //TODO: Implement specific question display
            return View("DisplayQuestion");
        }
    }
}
