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
    
    public partial class InteractionViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.Interaction>
    {
    	
    			public virtual int InteractionId { get; set; }
    			public virtual Nullable<int> SessionId { get; set; }
    			public virtual string InteractionName { get; set; }
    			public virtual Nullable<int> InteractionTypeId { get; set; }
    			public virtual Nullable<int> InteractionItemId { get; set; }
    			public virtual Nullable<bool> IsRunning { get; set; }
    	
    	public InteractionViewModel() : base() { }
    	public InteractionViewModel(HmsService.Models.Entities.Interaction entity) : base(entity) { }
    
    }
}
