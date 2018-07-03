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
            
            var listVoting = db.Votings.Where(a => a.EventId == 1).ToList().Select(a => new VotingViewModel
            {
                VotingID = a.VotingId,
                Name = a.VotingName,
                EventId = a.EventId,
                NumberOption = a.VotingOptions.Count

            });
            return listVoting;
        }

        [Route("AddVoting")]
        [HttpPost]
        public HttpResponseMessage AddVoting(Voting voting)
        {

            try
            {
                VotingApi votingApi = new VotingApi();
                int newVotingId = votingApi.BaseService.AddVoting(voting);

                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        votingId = newVotingId
                    })
                };
            }
            catch(Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false
                    })
                };
            }
        }

        [Route("GetVotingById")]
        [HttpPost]
        public HttpResponseMessage GetVotingById(Voting voting)
        {

            try
            {
                var votingTmp = db.Votings.Find(voting.VotingId);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        data = new VotingViewModel
                        {
                            VotingID = votingTmp.VotingId,
                            Name = votingTmp.VotingName,
                            EventId = votingTmp.EventId,
                            VotingOptions = votingTmp.VotingOptions.Select(v => new VotingOptionViewModel {
                                VotingOptionId = v.VotingOptionId,
                                VotingOptionContent = v.VotingOptionContent,
                                NumberOfVoting = v.NumberOfVoting,
                                VotingId = v.VotingId
                            })
                        }
                    })
                };
            }
            catch(Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false
                    })
                };
            }
         
        }

        [Route("UpdateVoting")]
        [HttpPost]
        public HttpResponseMessage UpdateVoting(Voting voting)
        {

            try
            {
                var votingApi = new VotingApi();
                votingApi.UpdateVoting(voting);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true
                    })
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false
                    })
                };
            }

        }

        [Route("DeleteVoting")]
        [HttpPost]
        public HttpResponseMessage DeleteVoting(Voting voting)
        {
            try
            {
                var votingApi = new VotingApi();
                bool isSuccess = votingApi.DeleteVoting(voting);
                if(isSuccess)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new JsonContent(new
                        {
                            success = true
                        })
                    };
                }
                else
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new JsonContent(new
                        {
                            success = false
                        })
                    };
                }
                

            }
            catch (Exception e)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new JsonContent(new
                    {
                        success = false,
                        data = e.Message
                    })
                };
            }

        }


    }


   
}
