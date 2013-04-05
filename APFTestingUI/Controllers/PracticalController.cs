using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APFTestingModel;
using APFTestingUI.Models.Practical;

namespace APFTestingUI.Controllers
{
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
            var packs = _facade.FetchAssessmentTasksPacker(examId);
            var model = new PackerView(examId, packs);
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
        public ActionResult PackerInput(PackerInput model)
        {
            // Generate struct for sending to facade
            // test for "Other" harness and canopy types
            return View();
        }

        //
        // GET: /Practical/PackerEdit

        //public ActionResult PackerEdit(Guid examId, Guid taskId)
        public ActionResult PackerEdit(Guid examId, Guid taskId)
        {
            var task = _facade.FetchSingleAssessmentTaskPacker(examId, taskId);
            var model = new PackerEdit(examId, task);
            return View(model);
        }

        //
        // POST: /Practical/PackerEdit

        [HttpPost]
        public ActionResult PackerEdit(PackerEdit model)
        {
            // generate struct for sending to facade
            // test for "Other" harness and canopy types
            return View();
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
