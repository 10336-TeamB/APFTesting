using APFTestingModel;
using APFTestingUI.Filters;
using System.Web.Mvc;

namespace APFTestingUI.Controllers 
{
    [InitializeSimpleMembership]
    public class HomeController : BaseController
    {
        public HomeController(IFacade facade) : base(facade) { }

        //
        // GET: /

        public ActionResult Index()
        {
			var userRole = User.GetType();
			if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", new { area = "Administration", controller = "Home" });
            }
            if (User.IsInRole("Examiner"))
            {
                return RedirectToAction("Index", "Examiner");
            }
			return RedirectToAction("Login", "Account");
        }
    }
}
