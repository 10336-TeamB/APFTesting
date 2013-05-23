using APFTestingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Controllers {
    public class HomeController : BaseController {
        public HomeController(IFacade facade) : base(facade) { }

        //
        // GET: /

        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", new { area = "Administration", controller = "Home" });
            }
            if (User.IsInRole("Examiner"))
            {
                return RedirectToAction("Index", "Examiner");
            }
            throw new Exception("User not valid");
        }
    }
}
