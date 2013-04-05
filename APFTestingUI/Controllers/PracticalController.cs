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
        // GET: /Practical/PilotInput

        public ActionResult PilotInput(Guid examId, Guid candidateId)
        {
            var tasks = _facade.FetchAssessmentTasks(examId);
            //var tasks = dummyTasks();
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
                    //_facade.SubmitPilotPracticalResults(results);
                    return RedirectToAction("PilotView", new { examId = model.ExamId, candidateId = model.CandidateId});
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
            return View(model);
        }

        //HACK: While no data available from Facade
        public IEnumerable<ISelectedAssessmentTask> dummyTasks()
        {

            yield return
                new DummyTask
                {
                    Title = "Local Knowledge",
                    Details = "Familiar with local requirements, noise, airspace, etc.",
                    MaxScore = 5,
                    Id = new Guid("00000000-0000-0000-0000-000000000001")
                };
            yield return
                new DummyTask
                {
                    Title = "Aircraft Knowledge",
                    Details = "Performance. Location of emergency equipment.",
                    MaxScore = 10,
                    Id = new Guid("00000000-0000-0000-0000-000000000002")
                };
            yield return
                new DummyTask
                {
                    Title = "Pre-Flight",
                    Details = "Aircraft prep, restraints, knife, airspace issues, weather brief, aircraft documents, e.g. maintenance release, Refuelling/Oil level.",
                    MaxScore = 10,
                    Id = new Guid("00000000-0000-0000-0000-000000000003")
                };
        } 

        //
        // GET: /Practical/PilotView

        public ActionResult PilotView(Guid examId, Guid candidateId)
        {
            var tasks = _facade.FetchAssessmentTasks(examId);
            var model = new PilotView(examId, candidateId, tasks);
            return View(model);
        }

        //
        // GET: /Practical/PilotSubmit

        public ActionResult PilotSubmit(Guid examId)
        {
            //var tasks = _facade.SubmitPilotPractical(examId);
            return RedirectToAction("Index", "Examiner");
        }

        #endregion

        #region Packer

        //
        // GET: /Practical/PackerView

        //Hack: add examId and CandidateId
        // public ActionResult PackerView(Guid examId, Guid candidateId)
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
        //public ActionResult PackerInput(Guid examId, Guid candidateId)
        public ActionResult PackerInput()
        {
            var examId = Guid.NewGuid();
            var candidateId = Guid.NewGuid();
            var model = new PackerInput(examId, candidateId);
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
    }
}
