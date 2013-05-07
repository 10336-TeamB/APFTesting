using APFTestingModel;
using APFTestingUI.Areas.Administration.Models.TheoryFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class TheoryFormatController : AdminBaseController
    {
        public TheoryFormatController(IFacade facade) : base(facade) { }
        //
        // GET: /Administration/TheoryFormat/

        public ActionResult Index()
        {
            var formats = _facade.FetchAllTheoryExamFormats();
            var model = new Index(formats);

            return View(model);
        }

    }
}
