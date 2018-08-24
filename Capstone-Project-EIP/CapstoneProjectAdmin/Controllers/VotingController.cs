using CapstoneProjectAdmin.Models;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class VotingController : Controller
    {
        // GET: Voting
        [Route("ManageVoting/{briefName}")]
        public ActionResult Index(string briefName)
        {
            EventApi eventApi = new EventApi();
            var eventTmp = eventApi.GetEventByBriefName(briefName);
            int id = eventTmp.EventID;
            ViewBag.EventId = id;
            ViewBag.BriefName = eventTmp.BriefName;
            return View();
        }
    }
}