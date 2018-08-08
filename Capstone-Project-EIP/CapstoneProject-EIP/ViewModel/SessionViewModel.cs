using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProject_EIP.ViewModel
{
    public class SessionViewModel
    {
        public virtual int SessionID { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<System.DateTime> StartTime { get; set; }
        public virtual Nullable<System.DateTime> EndTime { get; set; }
        public virtual string Description { get; set; }
        public virtual int EventId { get; set; }
        public virtual string LivestreamUrl { get; set; }
        public virtual string Address { get; set; }

        public IEnumerable<ActivityViewModel> Activities { get; set; }
    }
}