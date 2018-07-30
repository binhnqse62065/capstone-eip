using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProjectAdmin.Controllers
{
    public class ManageEventController : Controller
    {
        // GET: ManageEvent
        public ActionResult Index(int id)
        {
            ViewBag.EventId = id;
            CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
            var listCollection = collectionTypeApi.GetCollectionType();
            return View(listCollection);
        }

        public JsonResult AddNewCollectionType(CollectionType collectionType)
        {
            try
            {
                CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
                int collectionTypeId = collectionTypeApi.AddNewCollectionType(collectionType);
                return Json(new {
                    success = true,
                    Id = collectionTypeId,
                    Name = collectionType.Name
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }     
        }

        public JsonResult UpdateCollectionType(CollectionType collectionType)
        {
            try
            {
                CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
                collectionTypeApi.UpdateCollectionType(collectionType);
                return Json(new {
                    success = true
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
        }

        public JsonResult DeleteCollectionType(CollectionType collectionType)
        {
            try
            {
                CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
                collectionTypeApi.DeleteCollectionType(collectionType);
                return Json(new
                {
                    success = true
                });
            }
            catch
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        public ActionResult ManageCollectionItem()
        {
            return View("CollectionItem");
        }

        [Route("GetEventCollection/{eventId}/{typeId}")]
        public JsonResult GetEventCollection(int eventId, int typeId)
        {
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventCollection = eventCollectionApi
                .GetEventCollectionByType(eventId, typeId);
            return Json(new {
                data = eventCollection
            });
        }

        public JsonResult AddNewCollectionItem(CollectionItem collectionItem)
        {
            try
            {
                CollectionItemApi collectionItemApi = new CollectionItemApi();
                int collectionItemId =  collectionItemApi.AddNewCollectionItem(collectionItem);
                return Json(new {
                    success = true,
                    id = collectionItemId
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }
            
        }
    }
}