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
    //TODO: Add authorise attribute for an examiner & Candidate
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
            // BAD - Need to store password outside of public source code
            var password = "f53YvzQbk27x10XB0Dd";
            var modifiedId = examId.ToString() + password;
            byte[] input = Encoding.UTF8.GetBytes(modifiedId);
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

        //private Guid retrieveExamId(HttpCookie cookie)
        //{
        //    return new Guid(cookie.Value.Split('|')[0]);
        //}

        private Guid retrieveExamIdFromCookie(string cookieKey)
        {
            var cookie = Request.Cookies.Get(cookieKey);
            if (isValidCookie(cookie))
            {
                return new Guid(cookie.Value.Split('|')[0]);
            }
            throw new Exception("Suspect tampered cookie");
        }

        /*=====================================*/
        /*      INITIATE THEORY COMPONENT      */
        /*=====================================*/

		#region Initiate Theory Component

		// GET: /Exam/Start/
		public ActionResult Start(Guid examinerId, Guid candidateId)
		{
			var examId = _facade.StartTheoryComponent(examinerId, candidateId);
			var format = _facade.FetchTheoryComponentFormatForExam(examId);
			var model = new Instructions(examId, format);
            StoreExamCookie(examId);
			return View(model);
		}
        
        // GET: /Exam/Resume/
		public ActionResult Resume(Guid examId)
		{
            StoreExamCookie(examId);
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
            Guid examId = retrieveExamIdFromCookie("ExamId");
            var model = new QuestionDisplayItem(_facade.FetchFirstQuestion(examId), examId);
            return View("DisplayQuestion", model);
        }
        
        // GET: /Exam/NextQuestion/
        public ActionResult NextQuestion()
        {
            Guid examId = retrieveExamIdFromCookie("ExamId");
            var model = new QuestionDisplayItem(_facade.FetchNextQuestion(examId), examId);
            return View("DisplayQuestion", model);
        }
        
        // GET: /Exam/PreviousQuestion/
        public ActionResult PreviousQuestion()
        {
            Guid examId = retrieveExamIdFromCookie("ExamId");
            var model = new QuestionDisplayItem(_facade.FetchPreviousQuestion(examId), examId);
            return View("DisplayQuestion", model);
        }

        // GET: /Exam/ReviewQuestion/
        public ActionResult ReviewQuestion(int QuestionNumber)
        {
            --QuestionNumber; //back to index
            Guid examId = retrieveExamIdFromCookie("ExamId");
            var model = new QuestionDisplayItem(_facade.FetchSpecificQuestion(examId, QuestionNumber), examId);
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
                    return RedirectToAction("NextQuestion");
                case ExamAction.PreviousQuestion:
                    return RedirectToAction("PreviousQuestion");
                default:
                    return RedirectToAction("Summary");
            }
        }
		
		// GET: /Exam/Summary/
		public ActionResult Summary()
		{
            Guid examId = retrieveExamIdFromCookie("ExamId");
            var model = new TheoryComponentSummary(examId, _facade.FetchTheoryComponentSummary(examId));
            return View(model);
		}
		
		// GET: /Exam/Submit/
		[HttpGet]
		public ActionResult Submit()
		{
            Guid examId = retrieveExamIdFromCookie("ExamId");
            _facade.SubmitTheoryComponent(examId);
            return RedirectToAction("Result");
		}

		// GET: /Exam/Result/
		public ActionResult Result()
		{
            Guid examId = retrieveExamIdFromCookie("ExamId");
            if (Request.Cookies["ExamId"] != null)
            {
                var cookie = new HttpCookie("ExamId");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            var model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId));
            return View(model);
		}

        
        public ActionResult ReviewResult(Guid examId)
        {
            var model = new TheoryComponentResult(examId, _facade.FetchTheoryComponentResult(examId));
            return View("Result", model);
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
            try
            {
                _facade.VoidExam(model.ExamId, model.Username, model.Password);
            }
            catch (BusinessRuleException)
            {
                //TODO: Implement Voiding as an AJAX request, then error message can easily be displayed next to validation form.
                //TODO: Display error message to the user of failed login...
                return RedirectToAction("Resume", new { examId = model.ExamId });
            }
            
			return RedirectToAction("Index", "Examiner");
		}

        #endregion



	}
}
