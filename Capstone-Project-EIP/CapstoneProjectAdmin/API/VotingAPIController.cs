using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HmsService.Models.Entities;
using HmsService.Sdk;
using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/voting")]
    public class VotingAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();
        [Route("getAllVoting")]
        [HttpGet]
        public IEnumerable<VotingViewModel> GetVotings()
        {
            var listVoting = db.Votings.Where(a => a.VotingId == 1).ToList().Select(a => new VotingViewModel
            {
                VotingID = a.VotingId,
                Name = a.VotingName
               
            });
            return listVoting;
        }
    }
}
