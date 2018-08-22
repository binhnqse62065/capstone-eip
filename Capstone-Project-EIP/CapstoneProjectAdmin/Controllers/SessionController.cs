using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities;
using HmsService.Sdk;

namespace CapstoneProjectAdmin.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        private HmsEntities db = new HmsEntities();

        [Route("ManageSession/{briefName}")]
        public ActionResult Index(string briefName)
        {
            
            EventApi eventApi = new EventApi();
            var eventTmp = eventApi.GetEventByBriefName(briefName);
            ViewBag.EventId = eventTmp.EventID;
            ViewBag.BriefName = eventTmp.BriefName;
            string startDate = eventTmp.StartTime.Value.ToString("dd/MM/yyyy");
            string endDate = eventTmp.EndTime.Value.ToString("dd/MM/yyyy");
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

    }
}
