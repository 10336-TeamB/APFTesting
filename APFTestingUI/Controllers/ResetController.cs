using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APFTestingModel;

namespace APFTestingUI.Controllers
{
    public class ResetController : ApiController
    {
        private IFacade _facade;
        public ResetController(IFacade facade)
        {
            _facade = facade;
        }
        public void Reset()
        {
            _facade.ResetTheoryComponent();
        }
    }
}
