using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class VotingViewModel
    {
        public int VotingID { get; set; }
        public string Name { get; set; }

        public int EventId { get; set; }
        public int NumberOption { get; set; }
        public IEnumerable<VotingOptionViewModel> VotingOptions { get; set; }
    }
}