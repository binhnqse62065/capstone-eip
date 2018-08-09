using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class ActivityViewModel
    {
        public int ActivityID { get; set; }
        public string Name { get; set; }
        public int SessionId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Description { get; set; }
        public string SessionName { get; set; }
        public IEnumerable<string> SpeakerName { get; set; }
    }
}