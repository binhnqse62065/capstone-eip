//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HmsService.Models.Entities.Services
{
    using System;
    using System.Collections.Generic;
    
    
    public partial interface IActivityItemService : SkyWeb.DatVM.Data.IBaseService<ActivityItem>
    {
    }
    
    public partial class ActivityItemService : SkyWeb.DatVM.Data.BaseService<ActivityItem>, IActivityItemService
    {
        public ActivityItemService(SkyWeb.DatVM.Data.IUnitOfWork unitOfWork, Repositories.IActivityItemRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
