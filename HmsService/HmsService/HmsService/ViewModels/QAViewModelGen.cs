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
    
    public partial class QAViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<HmsService.Models.Entities.QA>
    {
    	
    			public virtual int QAId { get; set; }
    			public virtual string QAName { get; set; }
    			public virtual int EventId { get; set; }
    	
    	public QAViewModel() : base() { }
    	public QAViewModel(HmsService.Models.Entities.QA entity) : base(entity) { }
    
    }
}
