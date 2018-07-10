using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IInteractionService
    {
        int? GetVotingIdBySessionId(int sessionId);
    }
    public partial class InteractionService
    {
        public int? GetVotingIdBySessionId(int sessionId)
        {
            try
            {
                return this.FirstOrDefault(i => i.IsRunning == true && i.VotingId != null).VotingId;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
