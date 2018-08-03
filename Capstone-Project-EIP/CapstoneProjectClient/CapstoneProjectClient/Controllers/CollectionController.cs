using CapstoneProjectClient.ViewModel;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectClient.Controllers
{
    public class CollectionController : Controller
    {
        [Route("Collection/Index/{eventId}/{typeId}")]
        // GET: Collection
        public ActionResult Index(int eventId, int typeId)
        {
            ViewBag.EventId = eventId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(eventId).Select(c => new EventCollectionViewModel
            {
                Name = c.Name,
                TypeId = c.TypeId,
                EventId = c.EventId
            }).ToList();
            ViewBag.Collections = listCollection;
            var currentCollection = eventCollectionApi.GetEventCollectionByType(eventId, typeId);


            EventApi eventApi = new EventApi();
            var eventCurr = eventApi.BaseService.GetEventById(eventId);
            ViewBag.EventName = eventCurr.Name;

            

            return View(currentCollection);
        }
    }
}