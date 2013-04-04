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

        public ActionResult PilotInput()
        {
            var candidateId = new Guid("5e172e73-3237-45e0-9a03-0b8ed44f29a6");            
            //var tasks = _facade.FetchAssessmentTasks(candidateId);
            var tasks = dummyTasks();
            var model = new PilotInput(candidateId, tasks);
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
                    return RedirectToAction("PilotView");
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

        public ActionResult PilotView()
        {
            return View();
        }

        #endregion

        #region Packer
        //
        // GET: /Practical/PackerInput

        public ActionResult PackerInput()
        {
            return View();
        }

        //
        // GET: /Practical/PackerView

        public ActionResult PackerView()
        {
            return View();
        }

        #endregion
    }
}
