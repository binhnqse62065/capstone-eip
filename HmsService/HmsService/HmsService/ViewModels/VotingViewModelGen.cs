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
    
    public partial class VotingViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Voting>
    {
    	
    			public virtual int VotingId { get; set; }
    			public virtual string VotingName { get; set; }
    			public virtual int EventId { get; set; }
    	
    	public VotingViewModel() : base() { }
    	public VotingViewModel(HmsService.Models.Entities.Voting entity) : base(entity) { }
    
    }
}
