using APFTestingModel;
using APFTestingUI.Models.Examiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingUI.Filters;

namespace APFTestingUI.Controllers
{
    [InitializeSimpleMembership]
    public class ExaminerController : BaseController
    {
        public ExaminerController(IFacade facade) : base(facade) { }

        //
        // GET: /Examiner/
        //TODO : uncomment "Authorize"
        //[Authorize]
        public ActionResult Index()
        {
            
            //Displays list of candidates associated to this examiner
            //Fetch Canidates that are associated with this examiner.
            //HACK - ExaminerID hardcoded
            Guid ExaminerId = new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff");
            ViewBag.ExaminerName = User.Identity.Name;
            List<ExamType> ExaminerAuthority = new List<ExamType>();
            ExaminerAuthority.Add(ExamType.PilotExam);
            ExaminerAuthority.Add(ExamType.PackerExam);
            var model = new Index(_facade.FetchCandidates(ExaminerId), ExaminerId, ExaminerAuthority);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid && _facade.Login(model.UserName, model.Password, model.RememberMe))
            {
                return RedirectToAction("Index", "Examiner");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Logout()
        {
            _facade.Logout();
            return RedirectToAction("Index", "Examiner");
        }
    }
}
