using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class LunarCalendarApi
    {
        public IEnumerable<LunarCalendar> GetLunarCalendarByCollectionId(int storeId,int collectionId)
        {
            return this.BaseService.Get(q => q.Active && q.StoreId == storeId && q.CollectionId == collectionId).AsEnumerable(); 
        }
        public LunarCalendar GetItemById(int id)
        {
            return this.BaseService.Get(q => q.Active && q.Id == id).FirstOrDefault();
        }

        public PagingViewModel<LunarCalendarViewModel> GetAdminWithFilterAsync(int storeId, string keyword, int currPage, int pageSize, KeyValuePair<string, bool> sortKeyAsc, int filterCateId)
        {
            var pagedList = this.BaseService.GetAdminByStoreWithFilter(storeId, keyword, sortKeyAsc, filterCateId)
                .ProjectTo<LunarCalendarViewModel>(this.AutoMapperConfig);

            var afterPaging = pagedList.Page(currPage, pageSize);

            return new PagingViewModel<LunarCalendarViewModel>(afterPaging);
        }
        public async Task<LunarCalendarViewModel> GetDetailsByStoreIdAsync(int id, int storeId)
        {
            var entity = await this.BaseService.GetActiveDetailsByStoreAsync(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new LunarCalendarViewModel(entity);
            }
        }
        public async Task EditCalendarAsync(LunarCalendarViewModel model)
        {
            //model = Utils.ToExactType<LunarCalendarViewModel, LunarCalendarViewModel>(model);

            var entity = await this.BaseService.GetAsync(model.Id);
            model.CopyToEntity(entity);

            await this.BaseService.UpdateAsync(entity);
        }
        public async Task CreateCalendarAsync(LunarCalendarViewModel model)
        {
            var entity = model.ToEntity();
            await this.BaseService.CreateCalendarAsync(entity);
        }
    }
}
