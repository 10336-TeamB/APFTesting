using APFTestingModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace APFTestingUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected IFacade _facade;

        public BaseController(IFacade facade)
        {
            _facade = facade;
        }

        protected override void Dispose(bool disposing)
        {
            _facade.Dispose();
            base.Dispose(disposing);
        }
    }
}
