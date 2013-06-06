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

        private void deleteImage(string path)
        {
            var pathOfFileToDelete = Path.Combine(Server.MapPath("~/QuestionImages"), path);
            System.IO.File.Delete(pathOfFileToDelete);
        }

        private void manageImage(Edit model, out string fileName)
        {
            fileName = "";
            if (!model.DeleteImage)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImagePath != null)
                    {
                        deleteImage(model.ImagePath);

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
            }
            else
            {
                deleteImage(model.ImagePath);
            }
        }

        #region Pilot

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
        [ValidateAntiForgeryToken]
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
            if (question.EditableOrDeletable)
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
        [ValidateAntiForgeryToken]
        public ActionResult EditPilot(Edit model)
        {

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

                    string fileName;
                    manageImage(model, out fileName);
                    
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
                string imagePath;
                _facade.DeleteTheoryQuestion(questionId, ExamType.PilotExam, out imagePath);
                if (imagePath != null)
                {
                    deleteImage(imagePath);
                }
            }
            catch (BusinessRuleException ex)
            {
                return RedirectToAction("EditPilot", new { questionId = questionId, errorMessage = ex.Message });
            }

            return RedirectToAction("IndexPilot");
        }

        public ActionResult ToggleActivationPilot(Guid questionId)
        {
            _facade.ToggleTheoryQuestionActivation(questionId, ExamType.PilotExam);

            return RedirectToAction("IndexPilot");
        }

        public ActionResult DisplayPilot(Guid questionId)
        {
            var question = _facade.FetchTheoryQuestion(questionId);
            return View(new Display(question));
        }

        #endregion



        #region Packer

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
        [ValidateAntiForgeryToken]
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
            if (question.EditableOrDeletable)
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
        [ValidateAntiForgeryToken]
        public ActionResult EditPacker(Edit model)
        {
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
                    if (!model.DeleteImage)
                    {
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
                    }
                    else
                    {
                        var pathOfFileToDelete = Path.Combine(Server.MapPath("~/QuestionImages"), model.ImagePath);
                        System.IO.File.Delete(pathOfFileToDelete);
                    }

                    var questionPackage = new TheoryQuestionDetails(model.Description, fileName, model.Category, answers);

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
            _facade.ToggleTheoryQuestionActivation(questionId, ExamType.PackerExam);

            return RedirectToAction("IndexPacker");
        }

        public ActionResult DisplayPacker(Guid questionId)
        {
            var question = _facade.FetchTheoryQuestion(questionId);
            return View(new Display(question));
        }

        #endregion

        public ActionResult DeletePacker(Guid questionId)
        {
            try
            {
                string imagePath;
                _facade.DeleteTheoryQuestion(questionId, ExamType.PackerExam, out imagePath);
                if (imagePath != null)
                {
                    deleteImage(imagePath);
                }
            }
            catch (BusinessRuleException ex)
            {
                return RedirectToAction("EditPacker", new { questionId = questionId, errorMessage = ex.Message });
            }

            return RedirectToAction("IndexPacker");
        }

    }
}
