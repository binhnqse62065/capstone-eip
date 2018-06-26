using CapstoneProjectClient.Models;
using HmsService.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectClient.API
{
    [RoutePrefix("api/voting")]
    public class VotingController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("ChangeNumberOfVoting")]
        [HttpPost]
        public HttpResponseMessage ChangeNumberOfVoting(JObject requestObj)
        {
            var votingOption = db.VotingOptions.Find(requestObj.SelectToken("votingOptionId").ToObject<Int32>());
            votingOption.NumberOfVoting += 1;
            db.SaveChanges();
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    
                })
            };
        }

        [Route("Voting")]
        [HttpGet]
        public IEnumerable<VotingOption> Voting()
        {
            return db.VotingOptions.ToList();
        }
    }
}
