using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class InteractionViewModel
    {
        public int InteractionId { get; set; }
        public int SessionId { get; set; }
        public string InteractionName { get; set; }
        public Nullable<int> VotingId { get; set; }
        public Nullable<int> QAId { get; set; }
        public Nullable<bool> IsRunning { get; set; }
        public QAViewModel QA { get; set; }
        public VotingViewModel Voting { get; set; }
    }
}