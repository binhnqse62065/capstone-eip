using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class TimelineViewModel
    {
        public int SessionId { get; set; }
        public string TimelineTitle { get; set; }
        public string TimelineDetail { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}