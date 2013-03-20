using APFTestingModel;
using APFTestingUI.Models.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APFTestingUI.Controllers
{
    public class QuestionsController : ApiController
    {
        private IFacade _facade;
        public QuestionsController(IFacade facade)
        {
            _facade = facade;
        }
        
        // POST api/questions
        public HttpResponseMessage Post(AnsweredQuestion question)
        {
            try
            {
                _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);
                //throw new Exception("This is an ADAM test exception message");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
       
            //TODO: These Facade requests will also need exception handling for the view.
            QuestionDisplayItem newQuestion;
            switch (question.NavDirection)
            {
                case ExamAction.NextQuestion:
                    newQuestion = new QuestionDisplayItem(_facade.FetchNextQuestion(question.ExamId), question.ExamId);
                    break;
                default:
                    newQuestion = new QuestionDisplayItem(_facade.FetchPreviousQuestion(question.ExamId), question.ExamId);
                    break;
            }
            return Request.CreateResponse(HttpStatusCode.OK, newQuestion);
        }
    }
}
