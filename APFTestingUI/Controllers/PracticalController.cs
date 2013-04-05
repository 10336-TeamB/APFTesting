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

        //Hack: add examId and CandidateId
        // public ActionResult PackerView(Guid examId)
        public ActionResult PackerView()
        {
            var examId = Guid.NewGuid();
            var packs = dummyPacks();
            var model = new PackerView(examId, packs);
            return View(model);
        }

        private IEnumerable<IAssessmentTaskPacker> dummyPacks()
        {
            yield return new DummyPack()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                Date = DateTime.Now,
                CanopyType = "Canopy Type Other",
                CanopyTypeSerialNumber = "Canopy0001",
                HarnessContainerType = "Harness Not defined",
                HarnessContainerSerialNumber = "Harness0001",
                Note = "Packed very well1",
                SupervisorId = "006"
            };
            yield return new DummyPack()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                Date = DateTime.Now,
                CanopyType = "Canopy Type 2",
                CanopyTypeSerialNumber = "Canopy0002",
                HarnessContainerType = "Harness Container 2",
                HarnessContainerSerialNumber = "Harness0002",
                Note = "Packed very well2",
                SupervisorId = "007"
            };
            yield return new DummyPack()
            {
                Id = new Guid("00000000-0000-0000-0000-000000000006"),
                Date = DateTime.Now,
                CanopyType = "Canopy Type 3",
                CanopyTypeSerialNumber = "Canopy0003",
                HarnessContainerType = "Harness Container 3",
                HarnessContainerSerialNumber = "Harness0003",
                Note = "Packed very well3",
                SupervisorId = "008"
            };
        }

        //
        // GET: /Practical/PackerInput

        //HACK: reinstate
        //public ActionResult PackerInput(Guid examId)
        public ActionResult PackerInput()
        {
            var examId = Guid.NewGuid();
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
        public ActionResult PackerEdit()
        {
            // get AssessmentTaskPacker from facade
            // var task = _facade.FetchPackerTask(examId, taskId);
            var examId = Guid.NewGuid();
            var task = dummyPacks().First();
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
            var tasks = _facade.FinalisePractical(examId);
            return RedirectToAction("Index", "Examiner");
        }
    }
}
