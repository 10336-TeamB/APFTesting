using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.PracticalTemplatePacker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class PracticalTemplatePackerController : AdminBaseController
    {
        public PracticalTemplatePackerController(IFacade facade) : base(facade) { }

        //
        // GET: /Administration/PracticalTemplatePacker/Index

        public ActionResult Index(string displayMessage = "")
        {
            var templates = _facade.FetchAllPracticalComponentTemplatePackers();
            ViewBag.displayMessage = displayMessage;
            return View(new Index(templates));
        }

        //
        // GET: /Administration/PracticalTemplatePacker/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administration/PracticalTemplatePacker/Create

        [HttpPost]
        public ActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.CreatePracticalComponentTemplatePacker(model.NumOfRequiredAssessmentTasks);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //
        // GET: /Administration/PracticalTemplatePacker/Edit

        public ActionResult Edit(Guid templateId)
        {
            var model = new Edit(_facade.FetchPracticalTemplatePackerById(templateId));
            return View(model);
        }

        //
        // POST: /Administration/PracticalTemplatePacker/Edit

        [HttpPost]
        public ActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.EditPracticalComponentTemplatePacker(model.Id, model.NumOfRequiredAssessmentTasks);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //
        // GET: /Administration/PracticalTemplatePacker/Delete

        public ActionResult Delete(Guid templateId)
        {
            try
            {
                _facade.DeletePracticalTemplatePacker(templateId);
                return RedirectToAction("Index", new { displayMessage = "Template successfully deleted." });
            }
            catch (BusinessRuleException e)
            {
                return RedirectToAction("Index", new { displayMessage = e.Message });
            }
        }

        //
        // GET: /Administration/PracticalTemplatePacker/Activate

        public ActionResult Activate(Guid templateId)
        {
            try
            {
                _facade.SetActivePracticalTemplatePacker(templateId);
                return RedirectToAction("Index", new { displayMessage = "New template has been activated." });
            }
            catch (BusinessRuleException e)
            {
                return RedirectToAction("Index", new { displayMessage = e.Message });
            }
        }
    }
}
