using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IVotingService
    {
        int AddVoting(Voting voting);

        bool UpdateVoting(Voting voting);

        bool DeleteVoting(Voting voting);
        Voting GetVotingById(int id);
        IEnumerable<Voting> GetVotingByEventId(int eventId);

        
    }
    public partial class VotingService
    {
        public int AddVoting(Voting voting)
        {
            try
            {
                this.Create(voting);
                return voting.VotingId;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public bool UpdateVoting(Voting voting)
        {
            try
            {
                var votingUpdate = this.Get(voting.VotingId);
                votingUpdate.VotingName = voting.VotingName;
                this.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteVoting(Voting voting)
        {
            try
            {
                var votingDelete = this.Get(voting.VotingId);
                this.Delete(votingDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Voting GetVotingById(int id)
        {
            try
            {
                return this.FirstOrDefault(v => v.VotingId == id);
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public IEnumerable<Voting> GetVotingByEventId(int eventId)
        {
            try
            {
                return this.Get(v => v.EventId == eventId);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
