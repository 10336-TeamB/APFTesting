using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.QuestionManagement;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public ActionResult CreatePilot()
        {
            return View(new Create());
        }

        [HttpPost]
        public ActionResult CreatePilot(Create model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new BusinessRuleException("Test Exception");
                    List<AnswerDetails> answers = new List<AnswerDetails>();
                    for (int i = 0; i < model.Answers.Count; i++)
                    {
                        var answer = new AnswerDetails(model.Answers[i].Description, model.Answers[i].IsCorrect);
                        answers.Add(answer);
                    }

                    
                    //Image
                    var fileName = "";
                    if (model.ImageFile != null)
                    {
                        var extension = model.ImageFile.ContentType.Split('/');
                        var questionsWithImagesTotal = _facade.CountQuestionsWithImages();
                        fileName = String.Format("{0}.{1}", questionsWithImagesTotal, extension[1]);
                        var path = Path.Combine(Server.MapPath("~/QuestionImages"), fileName);
                        model.ImageFile.SaveAs(path);
                    }
                    
                    
                    var questionPackage = new TheoryQuestionDetails(model.Description, fileName, model.Category, answers);

                    _facade.CreateTheoryQuestion(questionPackage, ExamType.PilotExam);

                    return RedirectToAction("IndexPilot");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Exception", ex.Message);
                }
            }

            return View(model);
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


					var fileName = "";
					if (model.ImageFile != null)
					{
						if (model.ImagePath != null)
						{
							var pathOfFileToDelete = Path.Combine(Server.MapPath("~/QuestionImages"), model.ImagePath);
							System.IO.File.Delete(pathOfFileToDelete);

							var extension = (model.ImageFile.ContentType.Split('/'))[1];
							var currentFileName = (model.ImagePath.Split('.'))[0];
							fileName = String.Format("{0}.{1}", currentFileName, extension);

							var path = Path.Combine(Server.MapPath("~/QuestionImages"), fileName);
							model.ImageFile.SaveAs(path);
						}
						else
						{
							var extension = model.ImageFile.ContentType.Split('/');
							var questionsWithImagesTotal = _facade.CountQuestionsWithImages();
							fileName = String.Format("{0}.{1}", questionsWithImagesTotal, extension[1]);
							var path = Path.Combine(Server.MapPath("~/QuestionImages"), fileName);
							model.ImageFile.SaveAs(path);
						}

						
					}
					else
					{
						fileName = model.ImagePath;
					}

					var questionPackage = new TheoryQuestionDetails(model.Description, fileName, model.Category, answers);

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

        public ActionResult ToggleActivationPilot(Guid questionId)
        {
            _facade.ToggleTheoryQuestionActivation(questionId);

            return RedirectToAction("IndexPilot");
        }


		public ActionResult IndexPacker()
		{
            //return View(new IndexPilot(_facade.FetchAllTheoryQuestionsPilot()));
            //FetchAllTheoryQuestionsPacker()
            return View(new IndexPacker(_facade.FetchAllTheoryQuestionsPacker()));
		}


        [HttpGet]
        public ActionResult CreatePacker()
        {
            return View(new Create());
        }

        [HttpPost]
        public ActionResult CreatePacker(Create model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new BusinessRuleException("Test Exception");
                    List<AnswerDetails> answers = new List<AnswerDetails>();
                    for (int i = 0; i < model.Answers.Count; i++)
                    {
                        var answer = new AnswerDetails(model.Answers[i].Description, model.Answers[i].IsCorrect);
                        answers.Add(answer);
                    }

                    var questionPackage = new TheoryQuestionDetails(model.Description, "", model.Category, answers);

                    _facade.CreateTheoryQuestion(questionPackage, ExamType.PackerExam);

                    return RedirectToAction("IndexPacker");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Exception", ex.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditPacker(Guid questionId, string errorMessage = "")
        {
            var question = _facade.FetchTheoryQuestion(questionId);
            if (question.editableOrDeletable)
            {
                ModelState.AddModelError("Exception", errorMessage);
                return View(new Edit(question));
            }
            else
            {
                return RedirectToAction("IndexPacker");
            }
        }

        [HttpPost]
        public ActionResult EditPacker(Edit model)
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

                    return RedirectToAction("IndexPacker");
                }
                catch (BusinessRuleException ex)
                {
                    ModelState.AddModelError("Exception", ex.Message);
                }


            }

            return View(model);
        }

        public ActionResult ToggleActivationPacker(Guid questionId)
        {
            _facade.ToggleTheoryQuestionActivation(questionId);

            return RedirectToAction("IndexPacker");
        }



    }
}
