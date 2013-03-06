using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APFTestingUI.Controllers
{
    public class BaseController : Controller
    {
        protected Facade _facade = new Facade(ExamType.PilotExam);

        protected override void Dispose(bool disposing)
        {
            _facade.Dispose();
            base.Dispose(disposing);
        }
    }
}
