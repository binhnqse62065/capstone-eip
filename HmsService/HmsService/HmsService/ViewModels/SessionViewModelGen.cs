//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HmsService.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class SessionViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Session>
    {
    	
    			public virtual int SessionID { get; set; }
    			public virtual string Name { get; set; }
    			public virtual Nullable<System.DateTime> StartTime { get; set; }
    			public virtual Nullable<System.DateTime> EndTime { get; set; }
    			public virtual string Description { get; set; }
    			public virtual int EventId { get; set; }
    			public virtual string LivestreamUrl { get; set; }
    			public virtual string Address { get; set; }
                public virtual string EventName { get; set; }

        public SessionViewModel() : base() { }
    	public SessionViewModel(HmsService.Models.Entities.Session entity) : base(entity) { }
    
    }
}
