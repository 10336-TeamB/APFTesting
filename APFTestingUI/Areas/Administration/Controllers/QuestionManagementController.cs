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
            return View();
        }

        [HttpPost]
        public ActionResult CreatePilot(Create model)
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
