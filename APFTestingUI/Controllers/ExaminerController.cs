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
            Guid ExaminerId = Guid.NewGuid();
            var model = new Index(_facade.FetchCandidates(ExaminerId));
            return View(model);
        }



    }
}
