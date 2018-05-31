using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface ILunarCalendarService
    {
        IQueryable<LunarCalendar> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty, int filterCateId);
        Task<LunarCalendar> GetActiveDetailsByStoreAsync(int id, int storeId);
        System.Threading.Tasks.Task UpdateCalendarAsync(LunarCalendar entity);
        System.Threading.Tasks.Task CreateCalendarAsync(LunarCalendar entity);
    }

    public partial class LunarCalendarService:ILunarCalendarService
    {
        public IQueryable<LunarCalendar> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty,int filterCateId)
        {
            var entities = this.GetActive(q =>
                q.StoreId == storeId &&
                (keyword == null || q.ShortDate.ToString().Contains(keyword)));

            if (filterCateId != 0)
            {
                entities = entities.Where(q => q.CollectionId == filterCateId);
            }
            LunarCalendarSortableProperty name;
            if (orderByProperty.Key != null && Enum.TryParse(orderByProperty.Key, out name))
            {
                switch (name)
                {
                    case LunarCalendarSortableProperty.Id:
                        entities = entities.OrderBy(q => q.Id, orderByProperty.Value);
                        break;
                    case LunarCalendarSortableProperty.ShortDate:
                        entities = entities.OrderBy(q => q.ShortDate, orderByProperty.Value);
                        break;
                }
            }
            else
            {
                entities = entities.OrderByDescending(q => q.Id);
            }

            return entities;
        }
        public async Task<LunarCalendar> GetActiveDetailsByStoreAsync(int id, int storeId)
        {
            return await this.FirstOrDefaultActiveAsync(q => q.Id == id && q.StoreId == storeId);
        }
        public async System.Threading.Tasks.Task UpdateCalendarAsync(LunarCalendar entity)
        {
            await this.UpdateAsync(entity);
        }
        public async System.Threading.Tasks.Task CreateCalendarAsync(LunarCalendar entity)
        {
            await this.CreateAsync(entity);
        }
    }
    public enum LunarCalendarSortableProperty
    {
        Id,
        ShortDate,
    }
}
