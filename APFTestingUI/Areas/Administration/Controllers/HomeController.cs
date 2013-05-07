using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class HomeController : AdminBaseController
    {
        public HomeController(IFacade facade) : base(facade) { }
        
        //
        // GET: /Administration/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
