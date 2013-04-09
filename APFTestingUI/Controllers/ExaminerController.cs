using APFTestingModel;
using APFTestingUI.Models.Examiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Controllers
{
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
            Guid ExaminerId = new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff");
            ViewBag.ExaminerName = User.Identity.Name;
            List<ExamType> ExaminerAuthority = new List<ExamType>();
            ExaminerAuthority.Add(ExamType.PilotExam);
            ExaminerAuthority.Add(ExamType.PackerExam);
            var model = new Index(_facade.FetchCandidates(ExaminerId), ExaminerId, ExaminerAuthority);
            return View(model);
        }
    }
}
