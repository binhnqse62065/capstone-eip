using CapstoneProjectAdmin.Models;
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
    [RoutePrefix("api/sponsor")]
    public class SponsorController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("UpdateSponsorData")]
        [HttpPost]
        public HttpResponseMessage UpdateSponsorData(JObject requestObj)
        {
            var sponsor = db.CollectionItems.Find(requestObj.SelectToken("collectionItemId").ToObject<Int32>());
            var name = requestObj.SelectToken("collectionItemName").ToObject<String>();
            sponsor.Name = requestObj.SelectToken("collectionItemName").ToObject<String>();
            sponsor.Description = requestObj.SelectToken("collectionItemDescription").ToObject<String>();
            sponsor.ImageUrl = requestObj.SelectToken("collectionItemImageUrl").ToObject<String>();
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Update successful!",
                    data = new
                    {
                        sponsorName = sponsor.Name,
                        sponsorImage = sponsor.ImageUrl,
                        sponsorDescription = sponsor.Description
                    }
                })
            };
        }



        [Route("AddSponsor")]
        [HttpPost]
        public HttpResponseMessage AddSponsor(CollectionItem sponsor)
        {
            sponsor.EventCollectionId = 3;
            db.CollectionItems.Add(sponsor);
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    sponsorId = sponsor.CollectionItemID
                })
            };
        }

        [Route("DeleteSponsor")]
        [HttpPost]
        public HttpResponseMessage DeleteSponsor(CollectionItem sponsor)
        {
            var sponsorDelete = db.CollectionItems.Find(sponsor.CollectionItemID);
            db.CollectionItems.Remove(sponsorDelete);
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
