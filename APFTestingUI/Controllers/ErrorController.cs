using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace SurveyUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound() {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            //Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult ServerError() {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //Response.TrySkipIisCustomErrors = true;

            // Pass the exception into the view model for administrators eyes only
            //if (User.IsInRole("Administrator"))
            //{
                ViewBag.ExceptionMessage = Server.GetLastError().Message;
            //}

            return View();
        }

        // Shhh .. secret test method .. ooOOooOooOOOooohhhhhhhh
        public ActionResult ThrowError() {
            throw new NotImplementedException("Pew ^ Pew");
        }
    }
}
