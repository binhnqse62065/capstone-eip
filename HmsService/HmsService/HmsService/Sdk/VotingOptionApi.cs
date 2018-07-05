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
    }
}
