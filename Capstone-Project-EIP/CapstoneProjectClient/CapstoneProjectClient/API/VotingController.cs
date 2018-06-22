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
            //var votingQuestionId = requestObj.SelectToken("votingQuestionId").ToObject<Int32>();
            var votingOption = db.VotingOptions.Find(requestObj.SelectToken("votingOptionId").ToObject<Int32>());
            votingOption.NumberOfVoting += 1;
            db.SaveChanges();


            //var listVotingOption = db.VotingOptions.Where(v => v.VotingQuestionId == votingQuestionId);
            //int? totalVote = 0;
            //foreach(var item in listVotingOption)
            //{
            //    if (item.NumberOfVoting != null) totalVote += item.NumberOfVoting;   
            //}
            //float?[] listPercent = new float?[listVotingOption.Count()];
            //for(int i = 0; i < listVotingOption.Count(); i++)
            //{
            //    listPercent[i] = (float)listVotingOption.ElementAt(i).NumberOfVoting / totalVote;
            //}
            
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
