using APFTestingModel;
using APFTestingUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class AdminBaseController : BaseController
    {
        public AdminBaseController(IFacade facade) : base(facade) { }
    }
}
