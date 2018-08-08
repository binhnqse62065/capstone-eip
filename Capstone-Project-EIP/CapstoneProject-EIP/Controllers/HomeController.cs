using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProject_EIP.Models;
using CapstoneProject_EIP.ViewModel;
using HmsService.Sdk;

namespace CapstoneProject_EIP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        //    EventApi eventApi = new EventApi();
        //    var currEvent = eventApi.BaseService.GetEventById(1);
            //HmsEntities db = new HmsEntities();
            //var currEvent = db.Events.Find(1);
            EventApi eventApi = new EventApi();
            var currentEvent = eventApi.BaseService.FirstOrDefault(e => e.IsLandingPage == true);
            EventViewModel result = new EventViewModel
            {
                EventID = currentEvent.EventID,
                Name = currentEvent.Name,
                EventDescription = currentEvent.EventDescription,
                Address = currentEvent.Address,
                StartTime = currentEvent.StartTime,
                CodeLogin = currentEvent.CodeLogin,
                EndTime = currentEvent.EndTime,
                TemplateId = currentEvent.TemplateId,
                ImageURL = currentEvent.ImageURL,
                Longitude = currentEvent.Longitude,
                Latitude = currentEvent.Latitude,
                IsLandingPage = currentEvent.IsLandingPage,
                Sessions = currentEvent.Sessions.Select(s => new SessionViewModel
                {
                    SessionID = s.SessionID,
                    Name = s.Name,
                    Description = s.Description,
                    Activities = s.Activities.Select(a => new ActivityViewModel
                    {
                        ActivityID = a.ActivityID,
                        Description = a.Description,
                        EndTime = a.EndTime,
                        StartTime = a.StartTime,
                        Name = a.Name
                    })
                })
            };
            var listSpeaker = currentEvent.EventCollections.FirstOrDefault(c => c.TypeId == (int)MyEnums.CollectionType.Speaker);
            var listSponsor = currentEvent.EventCollections.FirstOrDefault(c => c.TypeId == (int)MyEnums.CollectionType.Sponsor);
            ViewBag.Speakers = listSpeaker;
            ViewBag.Sponsors = listSponsor;
            if (currentEvent.TemplateId == 1)
            {
                return View("Index", result);
            }
            else
            {
                return View("Index_2", result);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}