using APFTestingModel;
using APFTestingUI.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APFTestingUI.Controllers
{
    public class CandidateController : BaseController
    {
        public CandidateController(IFacade facade) : base(facade) { }

        #region Pilot

        //
        // GET: /Candidate/ViewPilot

        public ActionResult ViewPilot(Guid candidateId)
        {
            var model = new ViewPilot(_facade.FetchPilot(candidateId));
            return View(model);
        }

        //
        // GET: /Candidate/CreatePilot

        public ActionResult CreatePilot()
        {
            return View(new CreatePilot());
        }

        //
        // POST: /Candidate/CreatePilot

        [HttpPost]
        public ActionResult CreatePilot(CreatePilot model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Use proper examinerId
                    var examinerId = new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff");
                    var candidateId = _facade.CreateCandidate(model.Values, examinerId);
                    return RedirectToAction("ViewPilot", new { candidateId });
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }
           
            return View(model);
        }

        //
        // GET: /Candidate/EditPilot

        public ActionResult EditPilot(Guid candidateId)
        {
            var model = new EditPilot(_facade.FetchPilot(candidateId));
            return View(model);
        }

        //
        // POST: /Candidate/EditPilot

        [HttpPost]
        public ActionResult EditPilot(EditPilot model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.EditPilot(model.Id, model.Values);
                    return RedirectToAction("ViewPilot", new {candidateId = model.Id});
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
        // GET: /Candidate/ViewPacker

        public ActionResult ViewPacker(Guid candidateId)
        {
            var model = new ViewPacker(_facade.FetchPacker(candidateId));
            return View(model);
        }

        //
        // GET: /Candidate/CreatePacker

        public ActionResult CreatePacker()
        {
            return View();
        }

        //
        // POST: /Candidate/CreatePacker

        [HttpPost]
        public ActionResult CreatePacker(CreatePacker model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Use proper examinerId
                    var examinerId = new Guid("0099dcce-110a-4144-8ecb-80788f41e8ff");
                    var candidateId = _facade.CreateCandidate(model.Values, examinerId);
                    return RedirectToAction("ViewPacker", new { candidateId });
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }

            return View(model);
        }

        //
        // GET: /Candidate/EditPacker

        public ActionResult EditPacker(Guid candidateId)
        {
            var model = new EditPacker(_facade.FetchPacker(candidateId));
            return View();
        }

        //
        // POST: /Candidate/EditPacker

        [HttpPost]
        public ActionResult EditPacker(EditPacker model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _facade.EditPacker(model.Id, model.Values);
                    return RedirectToAction("ViewPacker", new {model.Id});
                }
                catch (BusinessRuleException e)
                {
                    ModelState.AddModelError("Exception", e.Message);
                }
            }

            return View(model);
        }

        #endregion
    }
}
