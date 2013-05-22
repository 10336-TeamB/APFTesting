using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using APFTestingUI.Models.Practical;

namespace APFTestingUI.Controllers
{
    [Authorize(Roles = "Examiner")]
    public class PracticalController : BaseController
    {
        public PracticalController(IFacade facade) : base(facade) { }

        #region Pilot

        //
        // GET: /Practical/PilotView

        public ActionResult PilotView(Guid examId, Guid candidateId)
        {
            var tasks = _facade.FetchAssessmentTasksPilot(examId);
            var model = new PilotView(examId, candidateId, tasks);
            return View(model);
        }

        //
        // GET: /Practical/PilotInput

        public ActionResult PilotInput(Guid examId, Guid candidateId)
        {
            var tasks = _facade.FetchAssessmentTasksPilot(examId);
            var model = new PilotInput(examId, candidateId, tasks);
            return View(model);
        }

        //
        // POST: /Practical/PilotInput

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PilotInput(PilotInput model)
        {
            if (ModelState.IsValid)
            {
                var results = new List<PilotPracticalResult>();
                foreach (var t in model.Tasks)
                {
                    results.Add(new PilotPracticalResult()
                    {
                        Id = t.Id,
                        Comment = t.Comment,
                        Score = int.Parse(t.Score)
                    });
                }
                try
                {
                    _facade.SubmitPilotPracticalResults(model.ExamId, results);
                    return RedirectToAction("PilotView", new { examId = model.ExamId, candidateId = model.CandidateId});
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        } 

        #endregion

        #region Packer

        //
        // GET: /Practical/PackerView

        public ActionResult PackerView(Guid examId)
        {
            bool isCompetent;
            var packs = _facade.FetchAssessmentTasksPacker(examId, out isCompetent);
            var model = new PackerView(examId, packs, isCompetent);
            return View(model);
        }

        //
        // GET: /Practical/PackerInput

        public ActionResult PackerInput(Guid examId)
        {
            var model = new PackerInput(examId);
            return View(model);
        }

        //
        // POST: /Practical/PackerInput

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PackerInput(PackerInput model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.SubmitPackerPracticalResult(model.ExamId, model.Values);
                    return RedirectToAction("PackerView", new { model.ExamId });
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //
        // GET: /Practical/PackerEdit

        public ActionResult PackerEdit(Guid examId, Guid taskId)
        {
            var task = _facade.FetchSingleAssessmentTaskPacker(examId, taskId);
            var model = new PackerEdit(examId, task);
            return View(model);
        }

        //
        // POST: /Practical/PackerEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PackerEdit(PackerEdit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.EditPackerPracticalResult(model.ExamId, model.TaskId, model.Values);
                    return RedirectToAction("PackerView", new { model.ExamId });
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        public ActionResult PackerSubmit(Guid examId)
        {
            _facade.FinalisePractical(examId);
            return RedirectToAction("Index", "Examiner");
        }
        
        #endregion

        //
        // GET: /Practical/FinalisePractical

        public ActionResult FinalisePractical(Guid examId)
        {
            _facade.FinalisePractical(examId);
            return RedirectToAction("Index", "Examiner");
        }
    }
}
