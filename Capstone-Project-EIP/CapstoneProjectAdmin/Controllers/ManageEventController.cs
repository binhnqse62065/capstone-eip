﻿using CapstoneProjectAdmin.ViewModel;
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
                Description = c.Description
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
                    description = eventCollection.Description
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
            return View("CollectionItem", eventCollection);
        }

        [Route("GetCollectionItem/{eventId}/{typeId}")]
        public JsonResult GetEventCollection(int eventId, int typeId)
        {
            EventCollectionApi eventCollectionApi = new EventCollectionApi();
            var eventCollection = eventCollectionApi
                .GetEventCollectionByType(eventId, typeId).CollectionItems.Select(i => new CollectionItemViewModel
                {
                    CollectionItemID = i.CollectionItemID,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl
                });
            return Json(new {
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
                    data = listCollectionType
                }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {
                    success = false
                });
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
    }
}