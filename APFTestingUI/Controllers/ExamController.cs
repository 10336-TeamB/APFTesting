﻿using APFTestingModel;
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

        private ActionResult checkForException(Action a)
        {
            try
            {
                a();
            } 
            catch (BusinessRuleExcpetion e)
            {
                return RedirectToAction("DisplayError", new { error = e.Message });
            }
            catch (Exception)
            {
                //Should we also provide all the messages from the inner exceptions? - Pradipna
                return RedirectToAction("DisplayError", new { error = "There was an error while submitting your answer" });
            }

            return null;
        }

        //
        // GET: /Exam/FirstQuestion/

        public ActionResult FirstQuestion(Guid examId)
        {
            QuestionDisplayItem model = null;
            Action a = delegate { model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, 0), examId); };
            ActionResult retActionResult = checkForException(a);
            return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        }

        //
        // GET: /Exam/NextQuestion/

        public ActionResult NextQuestion(Guid examId)
        {
            // TODO - Not sure if i'm happy with examId being passed in like this. Should ITheoryQuestion know this instead? - ADAM
            QuestionDisplayItem model = null;
            Action a = delegate { model = new QuestionDisplayItem(_facade.FetchNextQuestion(examId), examId); };
            ActionResult retActionResult = checkForException(a);
            return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        }

        //
        // GET: /Exam/PreviousQuestion/

        public ActionResult PreviousQuestion(Guid examId)
        {
            QuestionDisplayItem model = null;
            Action a = delegate { model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(examId), examId); };
            ActionResult retActionResult = checkForException(a);
            return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        }

        //
        // GET: /Exam/Resume/

        public ActionResult Resume(Guid examId)
        {
            QuestionDisplayItem model = null;
            Action a = delegate { model = new QuestionDisplayItem(_facade.ResumeTheoryExam(examId), examId); };
            ActionResult retActionResult = checkForException(a);
            return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        }

        //
        // GET: /Exam/Review/

        public ActionResult Review(Guid examId, int questionNumber)
        {
            QuestionDisplayItem model = null;
            Action a = delegate { model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber), examId); };
            ActionResult retActionResult = checkForException(a);
            if (retActionResult == null)
            {
                model.IsMarkedForReview = false;
                return View(model);
            }
            else
            {
                return retActionResult;
            } 
        }

        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            // TODO - Should we have a return value to confirm successful submission of answer?
            //We're gonna do it using exception - Pradipna
            Action a = delegate { _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview); };
            ActionResult retActionResult = checkForException(a);
            if (retActionResult == null)
            {
                switch (question.NavDirection)
                {
                    case ExamAction.NextQuestion:
                        return RedirectToAction("NextQuestion", new { examId = question.ExamId });
                    case ExamAction.PreviousQuestion:
                        return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
                    default:
                        return RedirectToAction("Summary", new { examId = question.ExamId });
                }
            }
            else
            {
                return retActionResult;
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
            //HACK - Commented out to prevent submission and allow playing with the UI
            //_facade.SubmitTheoryComponent(examId);
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

        [HttpGet]
        public ActionResult DisplayError(string error)
        {
            ViewBag.error = error;
            return View();
        }
    }
}
