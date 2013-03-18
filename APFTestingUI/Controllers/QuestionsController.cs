﻿using APFTestingModel;
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

        // GET api/questions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/questions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/questions
        public QuestionDisplayItem Post(AnsweredQuestion question)
        {
            _facade.AnswerQuestion(question.ExamId, question.Index, question.ChosenAnswer, question.IsMarkedForReview);
            switch (question.NavDirection)
            {
                case ExamAction.NextQuestion:
                    return new QuestionDisplayItem(_facade.FetchNextQuestion(question.ExamId), question.ExamId);
                default:
                    return new QuestionDisplayItem(_facade.FetchPreviousQuestion(question.ExamId), question.ExamId);
            }
        }

        // PUT api/questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        public void Delete(int id)
        {
        }
    }
}
