﻿using APFTestingModel;
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
            // var model = facade.FetchCandidate(candidateId);
            return View(new ViewPilot());
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
                    // Send data to facade

                    // Redirect
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
            //var model = new EditPilot(_facade.FetchCandidate(candidateId));
            return View();
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
                    // Send data to facade

                    // Redirect
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
            // var model = facade.FetchCandidate(candidateId);
            return View(new ViewPacker());
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
                    // Send data to facade

                    // Redirect
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
            //var model = new EditPacker(_facade.FetchCandidate(candidateId));
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
                    // Send data to facade

                    // Redirect
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