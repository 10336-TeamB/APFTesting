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
            Guid ExaminerId = new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff");
            var model = new Index(_facade.FetchCandidates(ExaminerId), ExaminerId);
            return View(model);
        }
    }
}
