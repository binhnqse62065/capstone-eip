using CapstoneProjectAdmin.ViewModel;
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
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var listCollection = eventCollectionApi.GetCollectionByEventId(id).Select(c => new EventCollectionViewModel
            {
                EventCollectionID = c.EventCollectionID,
                Name = c.Name,
                EventId = c.EventId,
                TypeId = c.TypeId,
                Description = c.Description,
                IsActive = (bool)c.IsActive,
                CollectionType = new CollectionTypeViewModel
                {
                    CollectionTypeID = c.CollectionType.CollectionTypeID,
                    Name = c.CollectionType.Name
                }
            });
            return View(listCollection);
        }

        [HttpPost]
        public JsonResult AddNewEventCollection(EventCollection eventCollection, string collectionTypeName)
        {
            try
            {
                EventCollectionApi eventCollectionApi = new EventCollectionApi();
                //Nếu không lựa collection type có sẵn thì tạo collecion type mới
                if (eventCollection.TypeId == -1)
                {
                    CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
                    int collectionTypeId = collectionTypeApi.AddNewCollectionType(collectionTypeName);
                    eventCollection.TypeId = collectionTypeId;
                }
                //tạo event collection
                eventCollectionApi.AddNewEventCollection(eventCollection);
                
                return Json(new {
                    success = true,
                    collectionTypeId = eventCollection.EventCollectionID,
                    name = eventCollection.Name,
                    description = eventCollection.Description,
                });
            }
            catch
            {
                return Json(new {
                    success = false
                });
            }     
        }

        public JsonResult UpdateCollectionType(EventCollection eventCollection)
        {
            try
            {
                EventCollectionApi eventCollectionApi = new EventCollectionApi();
                eventCollectionApi.UpdateEventCollection(eventCollection);
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

        public JsonResult DeleteEventCollection(EventCollection eventCollection)
        {
            try
            {
                EventCollectionApi eventCollectionApi = new EventCollectionApi();
                eventCollectionApi.DeleteEventCollection(eventCollection);
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

        [Route("ManageCollectionItem/{eventId}/{typeId}")]
        public ActionResult ManageCollectionItem(int eventId, int typeId)
        {
            ViewBag.EventId = eventId;
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventCollection = eventCollectionApi.GetEventCollectionByType(eventId, typeId);
            //var eventCollection = eventCollectionApi.GetEventCollectionById(eventCollectionId);
            return View("CollectionItem", eventCollection);
        }

        [Route("GetCollectionItem/{eventCollectionId}")]
        public JsonResult GetEventCollection(int eventCollectionId)
        {
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventCollection = eventCollectionApi
                .GetEventCollectionById(eventCollectionId).CollectionItems.Select(i => new CollectionItemViewModel
                {
                    CollectionItemID = i.CollectionItemID,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl
                });
            return Json(new
            {
                data = eventCollection
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddNewCollectionItem(CollectionItem collectionItem)
        {
            try
            {
                CollectionItemApi collectionItemApi = new CollectionItemApi();
                int collectionItemId =  collectionItemApi.AddNewCollectionItem(collectionItem);
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

        [HttpGet]
        public JsonResult GetCollectionType()
        {
            try
            {
                CollectionTypeApi collectionTypeApi = new CollectionTypeApi();
                var listCollectionType = collectionTypeApi.GetCollectionType();
                return Json(new {
                    success = true,
                    data = listCollectionType.Skip(2)
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteCollectionItem(CollectionItem collectionItem)
        {
            try
            {
                CollectionItemApi collectionItemApi = new CollectionItemApi();
                collectionItemApi.DeleteCollectionItem(collectionItem);
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

        public JsonResult UpdateCollectionItem(CollectionItem collectionItem)
        {
            try
            {
                CollectionItemApi collectionItemApi = new CollectionItemApi();
                collectionItemApi.UpdateCollectionItem(collectionItem);
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

        [Route("GetListTypeIdOfEvent/{eventId}")]
        public JsonResult GetListTypeIdOfEvent(int eventId)
        {
            try
            {
                EventCollectionApi eventCollectionApi = new EventCollectionApi();
                var listTypeId = eventCollectionApi.GetCollectionByEventId(eventId).Select(e => e.TypeId);
                return Json(new {
                    success = true,
                    data = listTypeId
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {
                    success = false
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}