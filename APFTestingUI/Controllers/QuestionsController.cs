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
    [Authorize]
    public class QuestionsController : ApiController
    {
        private IFacade _facade;
        public QuestionsController(IFacade facade)
        {
            _facade = facade;
        }
        
        // POST api/questions
        public QuestionDisplayItem Post(AnsweredQuestion question)
        {
            try
            {
                _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);
                //throw new Exception("This is an ADAM test exception message");
            }
            catch (BusinessRuleException e)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
               {
                   Content = new StringContent(e.Message)
               };
               throw new HttpResponseException(resp);
            }
       
            //TODO: These Facade requests will also need exception handling for the view.
            switch (question.NavDirection)
            {
                case ExamAction.NextQuestion:
                    return new QuestionDisplayItem(_facade.FetchNextQuestion(question.ExamId), question.ExamId);
                default:
                    return new QuestionDisplayItem(_facade.FetchPreviousQuestion(question.ExamId), question.ExamId);
            }
        }
    }
}
