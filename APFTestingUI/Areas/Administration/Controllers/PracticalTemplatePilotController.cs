using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.PracticalTemplatePilot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class PracticalTemplatePilotController : AdminBaseController
    {
        public PracticalTemplatePilotController(IFacade facade) : base(facade) { }

        //
        // GET: /Administration/PracticalTemplatePilot/Index

        public ActionResult Index()
        {
            var templates = _facade.FetchAllPracticalComponentTemplatePilots();
            return View(new Index(templates));
        }

        //
        // GET: /Administration/PracticalTemplatePilot/Display

        public ActionResult Display(Guid templateId, string displayMessage = "")
        {
            var template = _facade.FetchPracticalTemplatePilotById(templateId);
            var model = new PilotTemplateDisplayItem(template);
            ViewBag.displayMessage = displayMessage;
            return View(model);
        }

        //
        // GET: /Administration/PracticalTemplatePilot/Create

        public ActionResult Create()
        {
            var model = new Create(_facade.FetchAllAssessmentTaskPilot());
            return View(model);
        }

        //
        // POST: /Administration/PracticalTemplatePilot/Create

        [HttpPost]
        public ActionResult Create(Create model)
        {
            var templateId = _facade.CreatePracticalComponentTemplatePilot(model.SelectedTasks);
            return RedirectToAction("Display", new { templateId, displayMessage = "Template successfully created." });
        }

        //
        // GET: /Administration/PracticalTemplatePilot/Edit

        public ActionResult Edit(Guid templateId)
        {
            var model = new Edit(_facade.FetchPracticalTemplatePilotById(templateId));
            return View(model);
        }

        //
        // POST: /Administration/PracticalTemplatePilot/Edit

        [HttpPost]
        public ActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var templateId = _facade.EditPracticalComponentTemplatePilot(model.Id, model.SelectedTasks);
                    return RedirectToAction("Display", new { templateId, displayMessage = "Template successfully updated." });
                }
                catch (BusinessRuleException e) {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);

        }

        //
        // GET: /Administration/PracticalTemplatePilot/Delete

        public ActionResult Delete()
        {
            return RedirectToAction("Index");
        }

        //
        // GET: /Administration/PracticalTemplatePilot/Activate

        public ActionResult Activate()
        {
            return RedirectToAction("Index");
        }
    }
}
