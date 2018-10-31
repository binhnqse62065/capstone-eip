using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HmsService.Sdk;
using System;

namespace HmsService.Sdk
{
    public partial class InteractionApi
    {
        public void AddNewInteraction(Interaction interaction)
        {
            this.BaseService.Create(interaction);
            this.BaseService.Save();
        }

        public void UpdateInteraction(Interaction interaction)
        {
            var interactionUpdate = this.BaseService.FirstOrDefault(i => i.InteractionId == interaction.InteractionId);
            interactionUpdate.InteractionName = interaction.InteractionName;
            if (interaction.VotingId == null)
            {
                interactionUpdate.QAId = interaction.QAId;
                interactionUpdate.VotingId = null;
            }
            else if (interaction.QAId == null)
            {
                interactionUpdate.VotingId = interaction.VotingId;
                interactionUpdate.QAId = null;
            }
            this.BaseService.Save();
        }

        public void DeleteInteraction(Interaction interaction)
        {

            var interactionDelItem = this.BaseService.FirstOrDefault(i => i.InteractionId == interaction.InteractionId);

            this.BaseService.Delete(interactionDelItem);
            this.BaseService.Save();
        }

        public int? GetVotingIdBySessionId(int sessionId)
        {
            return this.BaseService.GetVotingIdBySessionId(sessionId);
        }

        public int GetQaIdBySessionId(int sessionId)
        {
            return (int)this.BaseService.GetQaBySessionId(sessionId);
        }

        public IEnumerable<Interaction> GetInteractionNotRunningBySessionId(int sessionId)
        {
            return this.BaseService.Get(i => i.SessionId == sessionId && i.IsRunning == false).ToList();
        }

        public IEnumerable<Interaction> GetInteractionRunningBySessionId(int sessionId)
        {
            return this.BaseService.Get(i => i.SessionId == sessionId && i.IsRunning == true).ToList();
        }

        public bool PlayInteraction(Interaction interaction)
        {

            try
            {
                var interactionAll = this.BaseService.Get(e => e.SessionId == interaction.SessionId).ToList();
                var interactionIsRunning = interactionAll.Where(s => s.IsRunning == true).ToList();
                var interactionPlayItem = this.BaseService.FirstOrDefault(e => e.InteractionId == interaction.InteractionId);
                foreach (var item in interactionIsRunning)
                {
                    //if (interactionPlayItem.VotingId != null)
                    //{
                    //    if (item.VotingId != null)
                    //    {
                    //        item.IsRunning = false;
                    //    }
                    //}
                    //else
                    if (interactionPlayItem.QAId != null)
                    {
                        if (item.QAId != null)
                        {
                            item.IsRunning = false;
                        }
                    }
                }
                interactionPlayItem.IsRunning = true;
                this.BaseService.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
