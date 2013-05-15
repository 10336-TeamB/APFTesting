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

        ////
        //// GET: /Administration/PracticalTemplatePilot/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Administration/PracticalTemplatePilot/Create

        //[HttpPost]
        //public ActionResult Create(Create model)
        //{
        //    return RedirectToAction("Index");
        //}

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
