using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class EventCollectionViewModel
    {
        public int EventCollectionID { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public virtual CollectionTypeViewModel CollectionType { get; set; }
    }
}