using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HmsService.Models.Entities.Services;
using HmsService.Sdk;
using HmsService.Models.Entities;
using CapstoneProjectClient.ViewModel;

namespace CapstoneProjectClient.Controllers
{
    public class QAController : Controller
    {
        

        // GET: QA
        [Route("QA/Index/{eventId}/{sessionId}")]
        public ActionResult Index(int eventId, int sessionId)
        {

            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId,
                IsActive = (bool)c.IsActive
            }).ToList();
            ViewBag.Collections = listCollection;
            ViewBag.EventId = eventId;
            ViewBag.SessionId = sessionId;
            SessionApi sessionApi = new SessionApi();
            ViewBag.SessionName = sessionApi.GetSessionNameById(sessionId);



            InteractionApi interactionApi = new InteractionApi();
            QAApi qAApi = new QAApi();
            int qaId = interactionApi.GetQaIdBySessionId(sessionId);
            QA qa = qAApi.GetQaById(qaId);
           
            var listSession = sessionApi.GetSessionsByEventId(eventId);
            if (listSession.Count() == 1)
            {
                ViewBag.SessionNumber = 1;
            }
            /*
             * jObject là message lấy từ người dùng( gọi API)
             * notify là hàm để thông báo message đến toàn bộ người dùng khác
             */
            //IEnumerable<Customer> customers = null;
            //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            //if (context != null)
            //{
            //    context.Clients.All.addNewMessageToPage("Binh", "Hello");
            //}



            return View(qa);
        }

    }
}