using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectAdmin.ViewModel
{
    public class CollectionItemViewModel
    {
        public int CollectionItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int EventCollectionId { get; set; }
        public int EventId { get; set; }
    }
}