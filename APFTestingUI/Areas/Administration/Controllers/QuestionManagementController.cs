using APFTestingModel;
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
        public ActionResult EditPilot(Guid questionId, string errorMessage = "")
        {
            var question = _facade.FetchTheoryQuestion(questionId);
            if (question.editableOrDeletable)
            {
                ModelState.AddModelError("Exception", errorMessage);
                return View(new Edit(question));
            }
            else
            {
                return RedirectToAction("IndexPilot");
            }

            
        }

        [HttpPost]
        public ActionResult EditPilot(Edit model)
        {
            //TODO: throw error if any input fields are left blank
            
            if (ModelState.IsValid)
            {
                try
                {
                    List<AnswerDetails> answers = new List<AnswerDetails>();
                    for (int i = 0; i < model.Answers.Count; i++)
                    {
                        var answer = new AnswerDetails(model.Answers[i].Description, model.Answers[i].IsCorrect, model.Answers[i].Id);
                        answers.Add(answer);
                    }

                    var questionPackage = new TheoryQuestionDetails(model.Description, "", model.Category, answers);

                    _facade.EditTheoryQuestion(questionPackage, model.Id);

                    return RedirectToAction("IndexPilot");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Exception", ex.Message);
                }
                
                
            }

            return View(model);
        }

        public ActionResult DeletePilot(Guid questionId)
        {
            try
            {
                _facade.DeleteTheoryQuestion(questionId);
            }
            catch (BusinessRuleException ex)
            {
                return RedirectToAction("EditPilot", new { questionId = questionId, errorMessage = ex.Message });
            }

            return RedirectToAction("IndexPilot");
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
