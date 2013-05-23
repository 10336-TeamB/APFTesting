using APFTestingModel;
using APFTestingUI.Models.Examiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingUI.Filters;
using WebMatrix.WebData;

namespace APFTestingUI.Controllers
{
    [Authorize(Roles = "Examiner")]
    public class ExaminerController : BaseController
    {
        public ExaminerController(IFacade facade) : base(facade) { }

        //
        // GET: /Examiner/
        public ActionResult Index()
        {
            
            //Displays list of candidates associated to this examiner
            //Fetch Canidates that are associated with this examiner.
            //HACK - ExaminerID hardcoded
            var UserId = WebSecurity.CurrentUserId;
            var Examiner = _facade.FetchExaminer(UserId);
            ViewBag.ExaminerName = Examiner.FirstName;
            var model = new Index(_facade.FetchCandidates(Examiner.Id), Examiner);
            return View(model);
        }

        public ActionResult TestEmail()
        {
            _facade.FinaliseExam(new Guid("4e757211-8c7d-4f32-a4b0-418a8bfad189"), ExamType.PackerExam);
            return RedirectToAction("Index", "Examiner");
        }
    }
}
