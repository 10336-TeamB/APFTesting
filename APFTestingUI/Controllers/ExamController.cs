using APFTestingModel;
using APFTestingUI.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace APFTestingUI.Controllers
{
    //TODO: Add authorise attribute for an examiner
    public class ExamController : BaseController
    {
        public ExamController(IFacade facade) : base(facade) { }

        public void StoreExamCookie(Guid examId)
        {
            var hashedId = hashExamId(examId);
            var value = examId.ToString() + "|" + hashedId;
            var cookie = new HttpCookie("ExamId", value);
            Response.Cookies.Add(cookie);
        }

        private string hashExamId(Guid examId) 
        {
            // BAD
            var password = "f53YvzQbkU6EK10XB0Dd";
            var modifiedId = examId.ToString() + password;
            //UTF8Encoding encoding = new UTF8Encoding();
            //var testBytes = encoding.GetBytes(modifiedId);
            byte[] input = Encoding.UTF8.GetBytes(modifiedId);
            //bool equal = testBytes.Equals(input);
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(input);
            return BitConverter.ToString(hash).Replace("-", "");
        }

        private bool isValidCookie(HttpCookie cookie)
        {
            string[] kvp = cookie.Value.Split('|');
            var examId = kvp[0];
            var hashedValue = kvp[1];
            return hashedValue.Equals(hashExamId(new Guid(examId)));
        }

        private Guid retrieveExamId(HttpCookie cookie)
        {
            return new Guid(cookie.Value.Split('|')[0]);
        }

        /*=====================================*/
        /*      INITIATE THEORY COMPONENT      */
        /*=====================================*/

		#region Initiate Theory Component

		// GET: /Exam/Start/
		public ActionResult Start(Guid examinerId, Guid candidateId)
		{
            //TODO: return all required values from one DB call...
			var examId = _facade.StartTheoryComponent(examinerId, candidateId);
			var format = _facade.FetchTheoryComponentFormatForExam(examId);
			var model = new Instructions(examId, format);

            StoreExamCookie(examId);

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
        public ActionResult FirstQuestion()
        {
            var cookie = Request.Cookies.Get("ExamId");
            Guid examId;
            if (isValidCookie(cookie))
            {
                examId = retrieveExamId(cookie);
                var model = new QuestionDisplayItem(_facade.FetchFirstQuestion(examId), examId);

                return View("DisplayQuestion", model);
            }
            throw new Exception("Suspect tampered cookie");
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
        
		
        // POST: /Exam/SubmitAnswer/
        [HttpPost]
        public ActionResult SubmitAnswer(AnsweredQuestion question)
        {
            //TODO: How do we handle exceptions in this action? How do we redisplay the current question?
            _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);

            switch (question.FormNavDirection)
            {
                case ExamAction.NextQuestion:
                    return RedirectToAction("NextQuestion", new { examId = question.ExamId });
                case ExamAction.PreviousQuestion:
                    return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
                default:
                    return RedirectToAction("Summary", new { examId = question.ExamId });
            }
        }
		
		// GET: /Exam/Summary/
		public ActionResult Summary(Guid examId)
		{
			var model = new TheoryComponentSummary(examId, _facade.FetchTheoryComponentSummary(examId));
			
			return View(model);
		}
		
		// GET: /Exam/Submit/
		[HttpGet]
		public ActionResult Submit(Guid examId)
		{
			_facade.SubmitTheoryComponent(examId);
			return RedirectToAction("Result", new { examId });
		}

		// GET: /Exam/Result/
		public ActionResult Result(Guid examId)
		{
			var model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId));
			
			return View(model);
		}

		// GET: /Exam/DisplayError/
		public ActionResult DisplayError(string error)
		{
			ViewBag.error = error;
			return View();
		}

		// GET: /Exam/Void/
		public ActionResult Void(VoidExam model)
		{
			_facade.VoidExam(model.ExamId);

			return RedirectToAction("Index", "Examiner");
		}

        #endregion




		#region old code

		//[HttpGet]
		//public ActionResult Void(VoidExam model)
		//{
		//	//This should probably be an AJAX request so if it fails the question display is unaffected...
		//	//TODO: Request authorisation credentials
		//	//if (Membership.ValidateUser(model.Username, model.Password))
		//	//{
		//	_facade.VoidExam(model.ExamId);
		//	//}

		//	return RedirectToAction("Index", "Examiner");
		//}






		//[HttpGet]
		//public ActionResult Result(Guid examId)
		//{
		//	// We may need this to display what their score is as a mark/passmark
		//	//_facade.FetchTheoryExamFormatDetails();
		//	//_facade.FetchCandidateDetails();

		//	TheoryComponentResult model = null;
		//	Action a = delegate { model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId)); };
		//	ActionResult retActionResult = checkForException(a);
		//	return (retActionResult == null) ? View(model) : retActionResult;
		//}




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




		//private ActionResult checkForException(Action a)
		//{
		//	try
		//	{
		//		a();
		//	} 
		//	catch (BusinessRuleException e)
		//	{
		//		return RedirectToAction("DisplayError", new { error = e.Message });
		//	}
		//	catch (Exception)
		//	{
		//		//Should we also provide all the messages from the inner exceptions? - Pradipna
		//		return RedirectToAction("DisplayError", new { error = "There was an error while submitting your answer" });
		//	}

		//	return null;
		//}

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


		//public ActionResult Review(Guid examId, int questionNumber)
		//{
		//	QuestionDisplayItem model = null;
		//	Action a = delegate { model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, questionNumber), examId); };
		//	ActionResult retActionResult = checkForException(a);
		//	if (retActionResult == null)
		//	{
		//		model.IsMarkedForReview = false;
		//		return View(model);
		//	}
		//	else
		//	{
		//		return retActionResult;
		//	} 
		//}

		//[HttpPost]
		//public ActionResult SubmitAnswer(AnsweredQuestion question)
		//{
		//	// TODO - Should we have a return value to confirm successful submission of answer?
		//	//We're gonna do it using exception - Pradipna
		//	Action a = delegate { _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview); };
		//	ActionResult retActionResult = checkForException(a);
		//	if (retActionResult == null)
		//	{
		//		switch (question.FormNavDirection)
		//		{
		//			case ExamAction.NextQuestion:
		//				return RedirectToAction("NextQuestion", new { examId = question.ExamId });
		//			case ExamAction.PreviousQuestion:
		//				return RedirectToAction("PreviousQuestion", new { examId = question.ExamId });
		//			default:
		//				return RedirectToAction("Summary", new { examId = question.ExamId });
		//		}
		//	}
		//	else
		//	{
		//		return retActionResult;
		//	}
		//}






		//
		// GET: /Exam/Summary/





		//
		// GET: /Exam/Result/





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

		#endregion



	}
}
