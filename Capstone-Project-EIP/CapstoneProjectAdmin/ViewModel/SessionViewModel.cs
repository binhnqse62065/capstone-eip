using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class SessionViewModel
    {
        public int SessionID { get; set; }
        public string Name { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public string Description { get; set; }
        public int EventId { get; set; }

    }
}