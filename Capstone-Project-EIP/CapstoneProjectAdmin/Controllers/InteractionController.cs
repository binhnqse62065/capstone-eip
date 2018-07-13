using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        private HmsEntities db = new HmsEntities();
        public ActionResult Index(int id)
        {
            /*VotingApi votingApi = new VotingApi();
            var listVoting = votingApi.GetVotingByEventId(id);
            ViewBag.EventId = id;
            return View(listVoting);*/
            HmsEntities db = new HmsEntities();
            ViewBag.EventId = id;
            return View(db.Events.Find(id));
        }
    }
}