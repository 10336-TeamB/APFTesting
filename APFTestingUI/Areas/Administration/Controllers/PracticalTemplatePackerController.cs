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

        public ActionResult Index()
        {
            var templates = _facade.FetchAllPracticalComponentTemplatePackers();
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
            // TODO: Need to display a confirmation, plus exceptions if they occur...
            _facade.DeletePracticalTemplatePacker(templateId);

            return RedirectToAction("Index");
        }

        //
        // GET: /Administration/PracticalTemplatePacker/Activate

        public ActionResult Activate(Guid templateId)
        {
            // TODO: Need to display a confirmation, plus exceptions if they occur...
            _facade.SetActivePracticalTemplatePacker(templateId);
            return RedirectToAction("Index");
        }
    }
}
