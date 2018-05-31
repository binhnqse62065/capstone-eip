﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IWebCustomerFeedbackService : SkyWeb.DatVM.Data.IBaseService<WebCustomerFeedback>
    {
        IQueryable<WebCustomerFeedback> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty);
        System.Threading.Tasks.Task<WebCustomerFeedback> GetActiveByStoreAsync(int id, int storeId);
        void RecordIsRead(int id, int storeId);
    }

    public partial class WebCustomerFeedbackService
    {
        public IQueryable<WebCustomerFeedback> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty)
        {

            var result = this.GetActive(q =>
                q.StoreId == storeId &&
                (keyword == null || q.Content.Contains(keyword)));

            CustomerFeedbackSortableProperty name;
            if (orderByProperty.Key != null && Enum.TryParse(orderByProperty.Key, out name))
            {
                switch (name)
                {
                    case CustomerFeedbackSortableProperty.Id:
                        result = result.OrderBy(q => q.Id, orderByProperty.Value);
                        break;
                    case CustomerFeedbackSortableProperty.Title:
                        result = result.OrderBy(q => q.Title, orderByProperty.Value);
                        break;
                    case CustomerFeedbackSortableProperty.Fullname:
                        result = result.OrderBy(q => q.Fullname, orderByProperty.Value);
                        break;
                    case CustomerFeedbackSortableProperty.Email:
                        result = result.OrderBy(q => q.Email, orderByProperty.Value);
                        break;
                    case CustomerFeedbackSortableProperty.Phone:
                        result = result.OrderBy(q => q.Phone, orderByProperty.Value);
                        break;
                }
            }
            else
            {
                result = result.OrderByDescending(q => q.IsRead==false).ThenByDescending(q=>q.Phone);
            }

            return result;
        }

        public async System.Threading.Tasks.Task<WebCustomerFeedback> GetActiveByStoreAsync(int id, int storeId)
        {
            return await this.FirstOrDefaultActiveAsync(q => q.Id == id && q.StoreId == storeId);
        }

        public void RecordIsRead(int id, int storeId)
        {
            var entity = this.FirstOrDefaultActive(q => q.Id == id && q.StoreId == storeId);
            if (entity!=null)
            {
                entity.IsRead = true;
                this.Update(entity);
            }
        }
    }

    public enum CustomerFeedbackSortableProperty
    {
        Id, Title, Fullname, Email, Phone
    }

}
