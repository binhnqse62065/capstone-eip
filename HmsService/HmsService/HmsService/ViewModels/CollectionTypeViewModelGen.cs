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
    
    public partial class CollectionTypeViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.CollectionType>
    {
    	
    			public virtual int CollectionTypeID { get; set; }
    			public virtual string Name { get; set; }
    			public virtual Nullable<bool> IsActive { get; set; }
    	
    	public CollectionTypeViewModel() : base() { }
    	public CollectionTypeViewModel(HmsService.Models.Entities.CollectionType entity) : base(entity) { }
    
    }
}
