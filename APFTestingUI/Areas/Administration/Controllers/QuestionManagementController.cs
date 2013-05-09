﻿using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.QuestionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class QuestionManagementController : AdminBaseController
    {
        public QuestionManagementController(IFacade facade) : base(facade) { }
        
        public ActionResult IndexPilot()
        {
            return View(new IndexPilot(_facade.FetchAllTheoryQuestionsPilot()));
        }

        public ActionResult IndexPacker()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePilot()
        {
            return View(new Create());
        }

        [HttpPost]
        public ActionResult CreatePilot(Create model)
        {
			List<AnswerDetails> answers = new List<AnswerDetails>();
			for (int i = 0; i < model.Answers.Count; i++)
			{
                var answer = new AnswerDetails(model.Answers[i].Description, model.Answers[i].IsCorrect);
                answers.Add(answer);
			}

			var questionPackage = new TheoryQuestionDetails(model.Description, "", model.Category, answers);

			_facade.CreateTheoryQuestion(questionPackage, ExamType.PilotExam);

			return View();
        }

        [HttpGet]
        public ActionResult EditPilot(Guid questionId)
        {
            return View(new Edit(_facade.FetchTheoryQuestion(questionId)));
        }

        [HttpPost]
        public ActionResult EditPilot(Edit model)
        {
            List<AnswerDetails> answers = new List<AnswerDetails>();
            for (int i = 0; i < model.Answers.Count; i++)
            {
                var answer = new AnswerDetails(model.Answers[i].Description, model.Answers[i].IsCorrect, model.Answers[i].Id);
                answers.Add(answer);
            }

            var questionPackage = new TheoryQuestionDetails(model.Description, "", model.Category, answers);

            _facade.EditTheoryQuestion(questionPackage, model.Id);

            return View();
        }

        public ActionResult DeletePilot()
        {


            return View();
        }



        [HttpGet]
        public ActionResult CreatePacker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePacker(Create model)
        {
            return View();
        }

        


    }
}
