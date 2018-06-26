using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using CapstoneProjectAdmin.Models;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/speaker")]
    public class SpeakerController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("UpdateSpeakerData")]
        [HttpPost]
        public HttpResponseMessage UpdateSpeakerData(JObject requestObj)
        {
            var speaker = db.CollectionItems.Find(requestObj.SelectToken("collectionItemId").ToObject<Int32>());
            speaker.Name = requestObj.SelectToken("collectionItemName").ToObject<String>();
            speaker.Description = requestObj.SelectToken("collectionItemDescription").ToObject<String>();
            speaker.ImageUrl = requestObj.SelectToken("collectionItemImageUrl").ToObject<String>();
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

        [Route("AddSpeaker")]
        [HttpPost]
        public HttpResponseMessage AddSpeaker(CollectionItem speaker)
        {
            speaker.EventCollectionId = 2;
            db.CollectionItems.Add(speaker);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    sponsorId = speaker.CollectionItemID
                })
            };
        }

        [Route("DeleteSpeaker")]
        [HttpPost]
        public HttpResponseMessage DeleteSpeaker(CollectionItem speaker)
        {
            var speakerDelete = db.CollectionItems.Find(speaker.CollectionItemID);
            db.CollectionItems.Remove(speakerDelete);
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
