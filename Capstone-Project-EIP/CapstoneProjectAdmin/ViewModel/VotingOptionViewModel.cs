using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class VotingOptionViewModel
    {
        public int VotingOptionId { get; set; }
        public string VotingOptionContent { get; set; }
        public Nullable<int> NumberOfVoting { get; set; }
        public int VotingId { get; set; }
    }
}