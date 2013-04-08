using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using APFTestingModel;
using System.Web.Mvc;

namespace APFTestingUI.Controllers
{
    public class ResetController : BaseController
    {
        public ResetController(IFacade facade) : base(facade) { }

        public ActionResult Reset(Guid examId)
        {
            _facade.ResetTheoryComponent(examId);
            return RedirectToAction("Index", "Examiner");
        }
    }
}
