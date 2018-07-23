using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("GetAllFileByEventId/{eventId}")]
        [HttpGet]
        public IEnumerable<CollectionItemViewModel> GetAllFileByEventId(int eventId)
        {
            var file = db.EventCollections
                .FirstOrDefault(s => s.EventId == eventId && s.TypeId == (int)CollectionType.File)
                .CollectionItems
                .Select(s => new CollectionItemViewModel
                {
                    CollectionItemID = s.CollectionItemID,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    EventCollectionId = s.EventCollectionId,
                    EventId = eventId
                }).ToList();
            return file;
        }


        [Route("UpdateFileData")]
        [HttpPost]
        public HttpResponseMessage UpdateFileData(JObject requestObj)
        {
            var file = db.CollectionItems.Find(requestObj.SelectToken("collectionItemId").ToObject<Int32>());
            file.Name = requestObj.SelectToken("collectionItemName").ToObject<String>();
            file.Description = requestObj.SelectToken("collectionItemDescription").ToObject<String>();
            file.ImageUrl = requestObj.SelectToken("collectionItemImageUrl").ToObject<String>();
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Update successful!",

                })
            };

        }

        [Route("AddFile")]
        [HttpPost]
        public HttpResponseMessage AddFile(CollectionItem file)
        {
            file.EventCollectionId = 4;
            db.CollectionItems.Add(file);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    fileId = file.CollectionItemID
                })
            };
        }

        [Route("DeleteFile")]
        [HttpPost]
        public HttpResponseMessage DeleteFile(CollectionItem file)
        {
            var fileDelete = db.CollectionItems.Find(file.CollectionItemID);
            db.CollectionItems.Remove(fileDelete);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Remove successful!",
                })
            };
        }
    }
}
