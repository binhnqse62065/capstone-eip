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
    public class ManageSessionController : Controller
    {
        // GET: ManageSession
        [Route("ManageSessionInteract/{briefName}")]
        public ActionResult Index(string briefName)
        {
            SessionApi sessionApi = new SessionApi();
            QAApi qAApi = new QAApi();
            VotingApi votingApi = new VotingApi();
            EventApi eventApi = new EventApi();
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventTmp = eventApi.GetEventByBriefName(briefName);
            var id = eventTmp.EventID;
            ViewBag.EventId = id;
            ViewBag.BriefName = eventTmp.BriefName;

            var listSession = sessionApi.GetSessionsByEventId(id);
            var listQa = qAApi.GetQAByEventId(id);
            var listVoting = votingApi.GetVotingViewModelByEventId(id);
            var listSpeaker = eventCollectionApi.GetSpeakerByEventId(id);
            ViewBag.ListQA = listQa != null ? listQa : null;
            ViewBag.ListVoting = listVoting != null ? listVoting : null; 
            ViewBag.ListSpeaker = listSpeaker != null ? listSpeaker.CollectionItems : null;

            var firstSession = listSession.FirstOrDefault();
            if(firstSession != null)
            {
                string startDate = firstSession.StartTime.Value.ToString("dd/MM/yyyy");
                string endDate = firstSession.EndTime.Value.ToString("dd/MM/yyyy");
                ViewBag.StartDate = startDate;
                ViewBag.EndDate = endDate;
            }
            return View(listSession);
        }
    }
}