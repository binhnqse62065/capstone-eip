using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class ManageSessionController : Controller
    {
        // GET: ManageSession
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            SessionApi sessionApi = new SessionApi();
            QAApi qAApi = new QAApi();
            VotingApi votingApi = new VotingApi();
            EventApi eventApi = new EventApi();
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventTmp = eventApi.GetEventById(id);
            string startDate = eventTmp.StartTime.Value.ToString("dd/MM/yyyy");
            string endDate = eventTmp.EndTime.Value.ToString("dd/MM/yyyy");
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            var listSession = sessionApi.GetSessionsByEventId(id);
            var listQa = qAApi.GetQAByEventId(id);
            var listVoting = votingApi.GetVotingViewModelByEventId(id);
            var listSpeaker = eventCollectionApi.GetSpeakerByEventId(id);
            ViewBag.ListQA = listQa != null ? listQa : null;
            ViewBag.ListVoting = listVoting != null ? listVoting : null; 
            ViewBag.ListSpeaker = listSpeaker != null ? listSpeaker.CollectionItems : null;
            return View(listSession);
        }
    }
}