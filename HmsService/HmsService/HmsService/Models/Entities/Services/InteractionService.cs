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

        int? GetQaBySessionId(int sessionId);
    }
    public partial class InteractionService
    {
        public int? GetVotingIdBySessionId(int sessionId)
        {
            try
            {
                return this.FirstOrDefault(i => i.IsRunning == true && i.VotingId != null && i.SessionId == sessionId).VotingId;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public int? GetQaBySessionId(int sessionId)
        {
            try
            {
                return this.FirstOrDefault(i => i.IsRunning == true && i.QAId != null && i.SessionId == sessionId).QAId;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
