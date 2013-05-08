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

        //
        // GET: /Administration/TheoryFormat/Create

        public ActionResult Create()
        {
            return View(new Create());
        }

        //
        // POST: /Administration/TheoryFormat/Create

        [HttpPost]
        public ActionResult Create(Create model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.CreateTheoryExamFormat(model.ExamType, model.NumberOfQuestions, model.PassMark, model.TimeLimit);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //
        // GET: /Administration/TheoryFormat/Edit?formatId={formatId}

        public ActionResult Edit(Guid formatId)
        {
            var format = _facade.FetchTheoryExamFormatById(formatId);
            var model = new Edit(format);
            return View(model);
        }

        //
        // POST: /Administration/TheoryFormat/Edit

        [HttpPost]
        public ActionResult Edit(Edit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.EditTheoryExamFormat(model.Id, model.NumberOfQuestions, model.PassMark, model.TimeLimit);
                    return RedirectToAction("Index");
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //
        // GET: /Administration/TheoryFormat/Activate?formatId={formatId}

        public ActionResult Activate(Guid formatId)
        {
            _facade.SetActiveTheoryComponentFormat(formatId);
            return RedirectToAction("Index");
        }

        //
        // GET: /Administration/TheoryFormat/Delete?formatId={formatId}

        public ActionResult Delete(Guid formatId)
        {
            _facade.DeleteTheoryExamFormat(formatId);
            return RedirectToAction("Index");
        }
    }
}
