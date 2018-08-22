using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class QAController : Controller
    {
        // GET: QA
        [Route("ManageQA/{briefName}")]
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