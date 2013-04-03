using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;

namespace APFTestingUI.Controllers
{
    public class PracticalController : BaseController
    {
        public PracticalController(IFacade facade) : base(facade) { }

        #region Pilot

        //
        // GET: /Practical/PilotInput

        public ActionResult PilotInput()
        {
            var candidateId = new Guid("5e172e73-3237-45e0-9a03-0b8ed44f29a6");
            //Get PracticalComponent from facade
            var tasks = _facade.FetchAssessmentTasks(candidateId);
            return View();
        }

        //
        // GET: /Practical/PilotView

        public ActionResult PilotView()
        {
            return View();
        }

        #endregion

        #region Packer
        //
        // GET: /Practical/PackerInput

        public ActionResult PackerInput()
        {
            return View();
        }

        //
        // GET: /Practical/PackerView

        public ActionResult PackerView()
        {
            return View();
        }

        #endregion
    }
}
