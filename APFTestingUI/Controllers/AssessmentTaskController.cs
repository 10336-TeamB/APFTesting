using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using APFTestingUI.Models.PracticalManagement;

namespace APFTestingUI.Controllers
{
    public class AssessmentTaskController : BaseController
    {
        public AssessmentTaskController(IFacade facade) : base(facade) { }

        public ActionResult Index()
        {
            var model = new AssessmentTaskList() { AssessmentTasks  = _facade.FetchAllAssessmentTaskPilot().Select(a => new AssessmentTaskItem(a)).ToList() };
            return View(model);
        }

    }
}
