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
    public partial class VotingApi
    {
        public bool UpdateVoting(Voting voting)
        {
            try
            {
                this.BaseService.UpdateVoting(voting);
                var votingOptionApi = new VotingOptionApi();
                var curVoting = this.BaseService.Get(voting.VotingId);

                List<int> listOptions = new List<int>();
                List<int> listOptionsUpdate = new List<int>();
                IEnumerable<int> listOptionsDelete = new List<int>();
                foreach (var item in curVoting.VotingOptions)
                {
                    listOptions.Add(item.VotingOptionId);
                }
                

                foreach (var item in voting.VotingOptions)
                {
                    listOptionsUpdate.Add(item.VotingOptionId);
                    var optionTmp = votingOptionApi.BaseService.Get(item.VotingOptionId);
                    if(optionTmp == null)
                    {
                        item.NumberOfVoting = 0;
                        votingOptionApi.BaseService.Create(item);
                    }
                    else
                    {
                        votingOptionApi.BaseService.UpdateVotingOption(item);
                    }
                }

                listOptionsDelete = listOptions.Except(listOptionsUpdate);
                foreach(var item in listOptionsDelete)
                {
                    votingOptionApi.BaseService.DeleteVotingOptionById(item);
                }
                
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool DeleteVoting(Voting voting)
        {
            try
            {
                var votingOptionApi = new VotingOptionApi();
                var interactionApi = new InteractionApi();
                var listVotingInteraction = interactionApi.BaseService.Get(a => a.VotingId == voting.VotingId);
                if(listVotingInteraction.Count() == 0)
                {
                    var curVoting = this.BaseService.Get(voting.VotingId);
                    foreach (var votingOption in curVoting.VotingOptions.ToList())
                    {
                        votingOptionApi.BaseService.DeleteVotingOption(votingOption);
                    }
                    if (this.BaseService.DeleteVoting(curVoting))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
                
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Voting GetVotingById(int votingId)
        {
            if(votingId != 0)
            {
                return this.BaseService.GetVotingById(votingId);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Voting> GetVotingByEventId(int eventId)
        {
            return this.BaseService.GetVotingByEventId(eventId);
        }

        public IEnumerable<VotingViewModel> GetVotingViewModelByEventId(int eventId)
        {
            return this.BaseService.GetVotingByEventId(eventId).Select(v => new VotingViewModel {
                VotingId = v.VotingId,
                VotingName = v.VotingName,
                EventId = v.EventId
            });
        }
    }
}
