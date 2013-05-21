using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Controllers
{
    public class SuccessfulExamController : BaseController
    {
        public SuccessfulExamController(IFacade facade) : base(facade) { }

        public ActionResult Index(Guid examId)
        {
            return View();
        }

    }
}
