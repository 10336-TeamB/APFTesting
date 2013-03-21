using APFTestingModel;
using APFTestingUI.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace APFTestingUI.Controllers
{
    //TODO: Add authorise attribute for an examiner
    public class ExamController : BaseController
    {
        public ExamController(IFacade facade) : base(facade) { }

        /*=====================================*/
        /*      INITIATE THEORY COMPONENT      */
        /*=====================================*/

		#region Initiate Theory Component
		
<<<<<<< HEAD
		// GET: /Exam/Instructions/
		public ActionResult Instructions(Guid examinerId, Guid candidateId)
=======
		//
		// GET: /Exam/Start/
        
		public ActionResult Start(Guid examinerId, Guid candidateId)
>>>>>>> 1c323dd2257ec3f78f840451581dc3f0555a8875
		{
            //TODO: return all required values from one DB call...
			var examId = _facade.StartTheoryComponent(examinerId, candidateId);
			var format = _facade.FetchTheoryComponentFormat(examId);

			var model = new Instructions(examId, format);

			return View(model);
		}
        
        // GET: /Exam/Resume/
		public ActionResult Resume(Guid examId)
		{
			var model = new QuestionDisplayItem(_facade.ResumeTheoryComponent(examId), examId);
			
			return View("DisplayQuestion", model);
		}

		#endregion



        /*================================*/
        /*      SIT THEORY COMPONENT      */
        /*================================*/

        #region Sit Theory Component
        
        // GET: /Exam/FirstQuestion/
        public ActionResult FirstQuestion(Guid examId)
        {
            var model = new QuestionDisplayItem(_facade.FetchFirstQuestion(examId), examId);
            
            return View("DisplayQuestion", model);
        }
        
        // GET: /Exam/NextQuestion/
        public ActionResult NextQuestion(Guid examId)
        {
            var model = new QuestionDisplayItem(_facade.FetchNextQuestion(examId), examId);

            return View("DisplayQuestion", model);
        }
        
        // GET: /Exam/PreviousQuestion/
        public ActionResult PreviousQuestion(Guid examId)
        {
            var model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(examId), examId);

            return View("DisplayQuestion", model);
        }

        // GET: /Exam/ReviewQuestion/
        public ActionResult ReviewQuestion(Guid examId, int questionIndex)
        {
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionIndex), examId);
            model.IsMarkedForReview = false;

            return View(model);
        }
        
        // GET: /Exam/SubmitAnswer/
        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);

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

        #endregion










        //[HttpPost]
        //public ActionResult SubmitAnswer(AnsweredQuestion question)
        //{
        //    // TODO - Should we have a return value to confirm successful submission of answer?
        //    //We're gonna do it using exception - Pradipna
        //    Action a = delegate { _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview); };
        //    ActionResult retActionResult = checkForException(a);
        //    if (retActionResult == null)
        //    {
        //        switch (question.NavDirection)
        //        {
        //            case ExamAction.NextQuestion:
        //                return RedirectToAction("NextQuestion", new { examId = question.ExamId });
        //            case ExamAction.PreviousQuestion:
        //                return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
        //            default:
        //                return RedirectToAction("Summary", new { examId = question.ExamId });
        //        }
        //    }
        //    else
        //    {
        //        return retActionResult;
        //    }
        //}




        //public ActionResult ReviewQuestion(Guid examId, int questionNumber)
        //{
        //    QuestionDisplayItem model = null;
        //    Action a = delegate { model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber), examId); };
        //    ActionResult retActionResult = checkForException(a);
        //    if (retActionResult == null)
        //    {
        //        model.IsMarkedForReview = false;
        //        return View(model);
        //    }
        //    else
        //    {
        //        return retActionResult;
        //    }
        //}


        

        private ActionResult checkForException(Action a)
        {
            try
            {
                a();
            } 
            catch (BusinessRuleException e)
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

        

        

        

        //
        // GET: /Exam/PreviousQuestion/

        //public ActionResult PreviousQuestion(Guid examId)
        //{
        //    QuestionDisplayItem model = null;
        //    Action a = delegate { model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(examId), examId); };
        //    ActionResult retActionResult = checkForException(a);
        //    return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        //}

        //
        // GET: /Exam/Review/

        

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

            TheoryComponentResult model = null;
            Action a = delegate { model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId)); };
            ActionResult retActionResult = checkForException(a);
            return (retActionResult == null) ? View(model) : retActionResult;
        }

        [HttpGet]
        public ActionResult DisplayError(string error)
        {
            ViewBag.error = error;
            return View();
        }

        [HttpGet]
        public ActionResult Void(VoidExam model)
        {
            //This should probably be an AJAX request so if it fails the question display is unaffected...
            //TODO: Request authorisation credentials
            //if (Membership.ValidateUser(model.Username, model.Password))
            //{
            _facade.VoidExam(model.ExamId);
            //}
            
            return RedirectToAction("Index", "Examiner");
        }

        //public ActionResult FirstQuestion(Guid examId)
        //{
        //    QuestionDisplayItem model = null;
        //    Action a = delegate { model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, 0), examId); };
        //    ActionResult retActionResult = checkForException(a);
        //    return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        //}


        //
        // GET: /Exam/Resume/

        //public ActionResult Resume(Guid examId)
        //{
        //	//QuestionDisplayItem model = null;
        //	//Action a = delegate { model = new QuestionDisplayItem(_facade.ResumeTheoryExam(examId), examId); };
        //	//ActionResult retActionResult = checkForException(a);
        //	//return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        //	return null;
        //}


        //public ActionResult Start(Guid examinerId, Guid candidateId)
        //{
        //	ViewBag.ExamId = _facade.StartTheoryComponent(examinerId, candidateId);

        //	return View();
        //}

        //public ActionResult NextQuestion(Guid examId)
        //{
        //    // TODO - Not sure if i'm happy with examId being passed in like this. Should ITheoryQuestion know this instead? - ADAM
        //    QuestionDisplayItem model = null;
        //    Action a = delegate { model = new QuestionDisplayItem(_facade.FetchNextQuestion(examId), examId); };
        //    ActionResult retActionResult = checkForException(a);
        //    return (retActionResult == null) ? View("DisplayQuestion", model) : retActionResult;
        //}

    }
}
