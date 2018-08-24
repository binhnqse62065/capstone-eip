using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class EventViewModel
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string EventDescription { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Address { get; set; }
        public Nullable<int> TemplateId { get; set; }
        public Nullable<int> CodeLogin { get; set; }
        public string ImageURL { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string BriefName { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
    }
}