﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProjectClient.ViewModel
{
    public class EventCollectionViewModel
    {
        public int EventCollectionID { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
    }
}