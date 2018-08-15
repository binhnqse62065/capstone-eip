using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProject_EIP.ViewModel
{
    public class ActivityViewModel
    {
        public virtual int ActivityID { get; set; }
        public virtual string Name { get; set; }
        public virtual int SessionId { get; set; }
        public virtual Nullable<System.DateTime> StartTime { get; set; }
        public virtual Nullable<System.DateTime> EndTime { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<ActivityItem> ActivityItems { get; set; }

    }
}