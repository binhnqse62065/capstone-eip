using CapstoneProjectAdmin.Models;
using CapstoneProjectAdmin.ViewModel;
using HmsService.Models.Entities;
using HmsService.Sdk;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProjectAdmin.API
{
    [RoutePrefix("api/interaction")]
    public class InteractionAPIController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllInteractionNotRunning/{id}")]
        [HttpGet]
        public IEnumerable<InteractionViewModel> GetAllInteractionNotRunning(int id)
        {
            InteractionApi interactionApi = new InteractionApi();
            var listInteractionNotRunngning = interactionApi.GetInteractionNotRunningBySessionId(id);
            var result = listInteractionNotRunngning.Select(i => new InteractionViewModel
            {
                InteractionId = i.InteractionId,
                InteractionName = i.InteractionName,
                SessionId = i.SessionId,
                IsRunning = i.IsRunning,
                QAId = i.QAId,
                VotingId = i.VotingId,
                QA = i.QA != null ? new QAViewModel { Name = i.QA.QAName } : null,
                Voting = i.Voting != null ? new VotingViewModel { Name = i.Voting.VotingName } : null,

            }).ToList();
            //var interaction = db.Interactions.Where(s => s.SessionId == id).ToList();
            //var interactionIsNotRunning = interaction.Where(e => e.IsRunning == false).ToList();
            return result;
        }

        [Route("getIsRunningInteraction/{id}")]
        [HttpGet]
        public IEnumerable<InteractionViewModel> GetIsRunningInteraction(int id)
        {
            InteractionApi interactionApi = new InteractionApi();
            var listInteractionNotRunngning = interactionApi.GetInteractionRunningBySessionId(id);
            var result = listInteractionNotRunngning.Select(i => new InteractionViewModel
            {
                InteractionId = i.InteractionId,
                InteractionName = i.InteractionName,
                SessionId = i.SessionId,
                IsRunning = i.IsRunning,
                QAId = i.QAId,
                VotingId = i.VotingId,
                QA = i.QA != null ? new QAViewModel { Name = i.QA.QAName } : null,
                Voting = i.Voting != null ? new VotingViewModel { Name = i.Voting.VotingName } : null,

            }).ToList();
            return result;
        }


        [Route("GetAllInteractionBySessionId/{id}")]
        [HttpGet]
        public IEnumerable<Interaction> GetAllInteractionBySessionId(int id)
        {
            var interaction = db.Interactions.Where(e => e.SessionId == id).ToList();
            return interaction;
        }
        [Route("UpdateInteractionData")]
        [HttpPost]
        public HttpResponseMessage UpdateInteractionData(Interaction interaction)
        {
            try
            {
                InteractionApi interactionApi = new InteractionApi();
                interactionApi.UpdateInteraction(interaction);

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
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = false,
                        message = "Update fail!",

                    })
                };

            }
            

        }

        [Route("AddInteraction")]
        [HttpPost]
        public HttpResponseMessage AddInteraction(Interaction interaction)
        {
            try
            {
                InteractionApi interactionApi = new InteractionApi();
                interactionApi.AddNewInteraction(interaction);
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
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = false,
                        message = "Add fail!",
                    })
                };
            }
            

            
        }

        [Route("DeleteInteraction")]
        [HttpPost]
        public HttpResponseMessage DeleteInteraction(Interaction interaction)
        {
            try
            {
                InteractionApi interactionApi = new InteractionApi();
                interactionApi.DeleteInteraction(interaction);


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
            catch
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = false,
                        message = "Remove fail!",
                    })
                };
            }

            
        }

        [Route("StopInteraction")]
        [HttpPost]
        public HttpResponseMessage StopInteraction(Interaction interaction)
        {

            var interactionStopItem = db.Interactions.Find(interaction.InteractionId);
            interactionStopItem.IsRunning = false;
            db.SaveChanges();

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new JsonContent(new
                {
                    success = true,
                    message = "Stop successful!",
                })
            };
        }

        [Route("PlayInteraction")]
        [HttpPost]
        public HttpResponseMessage PlayInteraction(Interaction interaction)
        {
            InteractionApi interactionApi = new InteractionApi();
            bool isSucess = interactionApi.PlayInteraction(interaction);
            //var interactionAll = db.Interactions.Where(e => e.SessionId == interaction.SessionId).ToList();
            //var interactionIsRunning = interactionAll.Where(s => s.IsRunning == true).ToList();
            //var interactionPlayItem = db.Interactions.Find(interaction.InteractionId);
            //foreach (var item in interactionIsRunning)
            //{
            //    if(interactionPlayItem.VotingId != null)
            //    {
            //        if(item.VotingId != null)
            //        {
            //            item.IsRunning = false;
            //        }
            //    }else if (interactionPlayItem.QAId != null)
            //    {
            //        if (item.QAId != null)
            //        {
            //            item.IsRunning = false;
            //        }
            //    }
            //}
            //interactionPlayItem.IsRunning = true;
            //db.SaveChanges();
            if(isSucess)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = true,
                        message = "Play successful!",
                    })
                };
            }
            else
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new JsonContent(new
                    {
                        success = false,
                        message = "Play fail!",
                    })
                };
            }
            
        }

    }
}
