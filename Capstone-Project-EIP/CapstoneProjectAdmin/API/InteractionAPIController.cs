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
            var interactionUpdate = db.Interactions.Find(interaction.InteractionId);
            interactionUpdate.InteractionName = interaction.InteractionName;
            if(interaction.VotingId == null)
            {
                interactionUpdate.QAId = interaction.QAId;
                interactionUpdate.VotingId = null;
            } else if (interaction.QAId == null)
            {
                interactionUpdate.VotingId = interaction.VotingId;
                interactionUpdate.QAId = null;
            }
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

        [Route("AddInteraction")]
        [HttpPost]
        public HttpResponseMessage AddInteraction(Interaction interaction)
        {
            db.Interactions.Add(interaction);
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

        [Route("DeleteInteraction")]
        [HttpPost]
        public HttpResponseMessage DeleteInteraction(Interaction interaction)
        {
            var interactionDelItem = db.Interactions.Find(interaction.InteractionId);
            db.Interactions.Remove(interactionDelItem);
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
            var interactionAll = db.Interactions.Where(e => e.SessionId == interaction.SessionId).ToList();
            var interactionIsRunning = interactionAll.Where(s => s.IsRunning == true).ToList();
            var interactionPlayItem = db.Interactions.Find(interaction.InteractionId);
            foreach (var item in interactionIsRunning)
            {
                if(interactionPlayItem.VotingId != null)
                {
                    if(item.VotingId != null)
                    {
                        item.IsRunning = false;
                    }
                }else if (interactionPlayItem.QAId != null)
                {
                    if (item.QAId != null)
                    {
                        item.IsRunning = false;
                    }
                }
            }
            interactionPlayItem.IsRunning = true;
            db.SaveChanges();

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

    }
}
