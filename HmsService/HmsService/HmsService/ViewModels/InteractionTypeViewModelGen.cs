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
    
    public partial class InteractionTypeViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.InteractionType>
    {
    	
    			public virtual int InteractionTypeId { get; set; }
    			public virtual string InteractionName { get; set; }
    	
    	public InteractionTypeViewModel() : base() { }
    	public InteractionTypeViewModel(HmsService.Models.Entities.InteractionType entity) : base(entity) { }
    
    }
}
