using APFTestingModel;
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
        public ExamController(IFacade facade) : base(facade) { }

        //
        // GET: /Exam/Start/

        public ActionResult Start(Guid candidateId)
        {
            ViewBag.ExamId = _facade.CreateExam(Guid.NewGuid(), candidateId, ExamType.PilotExam);

            return View();
        }




        //
        // GET: /Exam/FirstQuestion/

        public ActionResult FirstQuestion(Guid examId)
        {
            var FirstQuestionIndex = 0;
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, FirstQuestionIndex), examId);
            return View("DisplayQuestion", model);
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
        // GET: /Exam/Resume/

        public ActionResult Resume(Guid examId)
        {
            var model = new QuestionDisplayItem(_facade.ResumeTheoryExam(examId), examId);
            return View("DisplayQuestion", model);
        }

        //
        // GET: /Exam/Review/

        public ActionResult Review(Guid examId, int questionNumber)
        {
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber), examId);
            model.IsMarkedForReview = false;
            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            // TODO - Should we have a return value to confirm successful submission of answer?
            _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);

            switch(question.NavDirection)
            {
                case ExamAction.NextQuestion:
                    return RedirectToAction("NextQuestion", new { examId = question.ExamId });
                case ExamAction.PreviousQuestion:
                    return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
                default:
                    return RedirectToAction("Summary", new { examId = question.ExamId });
            }
        }

        //
        // GET: /Exam/Summary/

        [HttpGet]
        public ActionResult Summary(Guid examId)
        {
            var model = new TheoryComponentSummary(examId, _facade.FetchTheoryComponentSummary(examId));
            return View(model);
        }

        //
        // GET: /Exam/Submit/

        [HttpGet]
        public ActionResult Submit(Guid examId)
        {
            _facade.SubmitTheoryComponent(examId);
            return RedirectToAction("Result", new { examId });
        }

        //
        // GET: /Exam/Result/

        [HttpGet]
        public ActionResult Result(Guid examId)
        {
            // We may need this to display what their score is as a mark/passmark
            //_facade.FetchTheoryExamFormatDetails();
            //_facade.FetchCandidateDetails();
            var model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId));
            return View(model);
        }
    }
}
