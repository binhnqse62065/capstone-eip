using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HmsService.Models.Entities;

namespace CapstoneProject_EIP.Models
{
    public class IndexPageViewModel
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public List<EventCollection> ListCollection { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public List<Session> ListSession { get; set; }

    }
}