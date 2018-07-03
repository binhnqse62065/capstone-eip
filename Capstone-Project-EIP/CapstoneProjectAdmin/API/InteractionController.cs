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
    [RoutePrefix("api/interaction")]
    public class InteractionController : ApiController
    {
        private HmsEntities db = new HmsEntities();

        [Route("getAllInteractionNotRunning")]
        [HttpGet]
        public IEnumerable<Interaction> GetAllInteractionNotRunning()
        {
            var interaction = db.Interactions.Where(s => s.SessionId == 1).ToList();
            var interactionIsNotRunning = interaction.Where(e => e.IsRunning == false).ToList();
            return interactionIsNotRunning;
        }

        [Route("getIsRunningInteraction")]
        [HttpGet]
        public IEnumerable<Interaction> GetIsRunningInteraction()
        {
            var interaction = db.Interactions.Where(e => e.SessionId == 1).ToList();
            var interactionIsRunning = interaction.Where(s => s.IsRunning == true).ToList();
            return interactionIsRunning;
        }

        [Route("UpdateInteractionData")]
        [HttpPost]
        public HttpResponseMessage UpdateInteractionData(Interaction interaction)
        {
            //var interaction = db.Interactions.Find(requestObj.SelectToken("interactionId").ToObject<Int32>());
            //interaction.InteractionName = requestObj.SelectToken("interactionName").ToObject<String>();
            //interaction.VotingId = requestObj.SelectToken("votingId").ToObject<Int32>();
            //interaction.QAId = requestObj.SelectToken("qaId").ToObject<Int32>();
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
            var interactionAll = db.Interactions.Where(e => e.SessionId == 1).ToList();
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
