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
    public partial class VotingOptionApi
    {
        public bool UpdateVotingOption(VotingOption option)
        {
            try
            {
                this.BaseService.Update(option);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddNewVotingOption(VotingOption option)
        {
            try
            {
                this.BaseService.Create(option);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<double> GetNewResultVoting(int votingId)
        {
            try
            {
                var listOption = this.BaseService.Get(v => v.VotingId == votingId);
                double totalVote = 0;
                //Get all total voting
                foreach(var option in listOption)
                {
                    totalVote += (int)option.NumberOfVoting;
                }
                //calculate percent each option
                List<double> listPercentOption = new List<double>();
                double percentTmp = 0;
                foreach(var option in listOption)
                {
                    percentTmp = Math.Round(((double)option.NumberOfVoting / totalVote) * 100);
                    listPercentOption.Add(percentTmp);
                }
                return listPercentOption;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
