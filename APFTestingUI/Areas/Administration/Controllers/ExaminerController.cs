using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingUI.Areas.Administration.Models.ExaminerManagement;
using APFTestingModel;
using APFTestingUI.Controllers;
using APFTestingUI.Filters;

namespace APFTestingUI.Areas.Administration.Controllers
{
    [InitializeSimpleMembership]
    public class ExaminerController : BaseController
    {
        public ExaminerController(IFacade _facade) : base(_facade) { }

        //
        // GET: /Administration/Examiner/

        public ActionResult Index()
        {
            var model = new Index(_facade.FetchAllExaminers());
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateExaminer());
        }

        [HttpPost]
        public ActionResult Create(CreateExaminer model)
        {
            if (ModelState.IsValid)
            {
                List<ExamType> authorities = new List<ExamType>();
                if (model.ExaminerPacker) authorities.Add(ExamType.PackerExam);
                if (model.ExaminerPilot) authorities.Add(ExamType.PilotExam);
                ExaminerDetails details = new ExaminerDetails(model.FirstName, model.LastName, model.Password, model.APFNumber, authorities);
                _facade.CreateExaminer(details);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid examinerId)
        {
            IExaminer examiner = _facade.FetchExaminer(examinerId);
            EditExaminer model = new EditExaminer(examiner);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Guid examinerId, EditExaminer model)
        {
            List<ExamType> authorities = new List<ExamType>();
            if (model.ExaminerPacker) authorities.Add(ExamType.PackerExam);
            if (model.ExaminerPilot) authorities.Add(ExamType.PilotExam);
            ExaminerDetails details = new ExaminerDetails(model.FirstName, model.LastName, model.NewPassword, model.APFNumber, authorities);
            details.OldPassword = model.OldPassword;
            _facade.EditExaminer(examinerId, details);
            return RedirectToAction("Index");
        }

        public ActionResult Activate(Guid examinerId)
        {
            _facade.EditExaminerActiveStatus(examinerId, true);
            return RedirectToAction("Index");
        }

        public ActionResult Deactivate(Guid examinerId)
        {
            _facade.EditExaminerActiveStatus(examinerId, false);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid examinerId)
        {
            _facade.DeleteExaminer(examinerId);
            return RedirectToAction("Index");
        }
    }
}
