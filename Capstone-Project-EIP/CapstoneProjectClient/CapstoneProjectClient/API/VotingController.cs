﻿using CapstoneProjectClient.Models;
using HmsService.Models.Entities;
using HmsService.Sdk;
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
        public HttpResponseMessage ChangeNumberOfVoting(VotingOption option)
        {
            //var votingOption = db.VotingOptions.Find(option.VotingOptionId);
            //votingOption.NumberOfVoting += 1;
            //db.SaveChanges();


            VotingOptionApi votingOptionApi = new VotingOptionApi();
            votingOptionApi.ChangeNumberOfVotingOption(option);
            
            List<double> listPercentOption = votingOptionApi.GetNewResultVoting(option.VotingId);
            
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    data = listPercentOption
                })
            };
        }

        [Route("ShowResultOfVoting")]
        [HttpPost]
        public HttpResponseMessage ShowResultOfVoting(VotingOption option)
        {
            VotingOptionApi votingOptionApi = new VotingOptionApi();

            List<double> listPercentOption = votingOptionApi.GetNewResultVoting(option.VotingId);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Add successful!",
                    data = listPercentOption
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
