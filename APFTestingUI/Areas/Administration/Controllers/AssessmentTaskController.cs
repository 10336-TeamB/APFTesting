using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.AssessmentTaskManagement;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class AssessmentTaskController : AdminBaseController
    {
        public AssessmentTaskController(IFacade facade) : base(facade) { }

        public ActionResult Index()
        {
            var model = new AssessmentTaskList() { AssessmentTasks  = _facade.FetchAllAssessmentTaskPilot().Select(a => new AssessmentTaskItem(a)).ToList() };
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = new AssessmentTaskItem(_facade.FetchAssessmentTaskPilot(id));
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateAssessmentTask model)
        {
            if (ModelState.IsValid)
            {
                var assessmentTask = _facade.CreateAssessmentTaskPilot(model.AssessmentTaskDetails);
                return RedirectToAction("Details", new { id = assessmentTask.Id });
            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            var model = new EditAssessmentTask(_facade.FetchAssessmentTaskPilot(id));
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditAssessmentTask model)
        {
            if (ModelState.IsValid)
            {
                _facade.EditAssessmentTaskPilot(model.Id, model.AssessmentTaskDetails);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                _facade.DeleteAssessmentTaskPilot(id);
                ViewBag.Message = "Assessment Task Deleted";
            }
            catch(Exception)
            {
                ViewBag.Message = "Assessment Task could not be deleted";
            }
            return View("DeletedConfirmation");
        }

    }
}
