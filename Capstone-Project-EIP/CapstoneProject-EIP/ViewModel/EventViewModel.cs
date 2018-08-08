using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProject_EIP.ViewModel
{
    public class EventViewModel
    {
        public virtual int EventID { get; set; }
        public virtual string Name { get; set; }
        public virtual string EventDescription { get; set; }
        public virtual Nullable<System.DateTime> StartTime { get; set; }
        public virtual Nullable<System.DateTime> EndTime { get; set; }
        public virtual Nullable<System.DateTime> CreateTime { get; set; }
        public virtual string Address { get; set; }
        public virtual Nullable<int> TemplateId { get; set; }
        public virtual Nullable<int> CodeLogin { get; set; }
        public virtual string ImageURL { get; set; }
        public virtual Nullable<bool> IsActive { get; set; }
        public virtual Nullable<double> Longitude { get; set; }
        public virtual Nullable<double> Latitude { get; set; }
        public virtual Nullable<bool> IsLandingPage { get; set; }

        public IEnumerable<SessionViewModel> Sessions { get; set; }
    }
}