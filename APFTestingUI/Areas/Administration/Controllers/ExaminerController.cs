using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingUI.Areas.Administration.Models.ExaminerManagement;
using APFTestingModel;
using APFTestingUI.Controllers;

namespace APFTestingUI.Areas.Administration.Controllers
{
    public class ExaminerController : BaseController
    {
        public ExaminerController(IFacade _facade) : base(_facade) { }

        //
        // GET: /Administration/Examiner/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateExaminer());
        }

        [HttpPost]
        public ActionResult Create(CreateExaminer model)
        {
            List<ExamType> authorities = new List<ExamType>();
            if (model.ExaminerPacker) authorities.Add(ExamType.PackerExam);
            if (model.ExaminerPilot) authorities.Add(ExamType.PilotExam);
            ExaminerDetails details = new ExaminerDetails(model.FirstName, model.LastName, model.Username, model.Password, model.APFNumber, authorities);
            _facade.CreateExaminer(details);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid examinerId)
        {
            return View(new EditExaminer());
        }

        [HttpPost]
        public ActionResult Edit(EditExaminer model)
        {
            return View("Index");
        }
    }
}
