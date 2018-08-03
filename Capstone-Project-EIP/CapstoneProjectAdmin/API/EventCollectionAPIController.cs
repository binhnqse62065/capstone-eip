using HmsService.Models.Entities;
using HmsService.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/collection")]
    public class EventCollectionAPIController : ApiController
    {
        [Route("AddCollection")]
        [HttpPost]
        public HttpResponseMessage AddNewEventCollection(EventCollection eventCollection, string collectionTypeName)
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
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

            }
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
