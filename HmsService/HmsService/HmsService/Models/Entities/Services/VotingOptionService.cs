using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IVotingOptionService
    {
        bool UpdateVotingOption(VotingOption option);

        bool DeleteVotingOption(VotingOption option);

        bool DeleteVotingOptionById(int id);
    }
    public partial class VotingOptionService
    {
       
        public bool UpdateVotingOption(VotingOption option)
        {
            try
            {
                var curOption = this.Get(option.VotingOptionId);
                curOption.VotingOptionContent = option.VotingOptionContent;
                this.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteVotingOption(VotingOption option)
        {
            try
            {
                var curOption = this.Get(option.VotingOptionId);
                this.Delete(curOption);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteVotingOptionById(int id)
        {
            try
            {
                var curOption = this.Get(id);
                this.Delete(curOption);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
