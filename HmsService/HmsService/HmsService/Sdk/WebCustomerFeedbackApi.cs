using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;

namespace HmsService.Sdk
{
    public partial class WebCustomerFeedbackApi
    {

        public PagingViewModel<WebCustomerFeedbackViewModel> GetAdminWithFilterAsync(int storeId, string keyword, int currPage, int pageSize, KeyValuePair<string, bool> sortKeyAsc)
        {
            var pagedList = this.BaseService.GetAdminByStoreWithFilter(storeId, keyword, sortKeyAsc)
                .ProjectTo<WebCustomerFeedbackViewModel>(this.AutoMapperConfig);

            var afterPaging = pagedList.Page(currPage, pageSize);

            return new PagingViewModel<WebCustomerFeedbackViewModel>(afterPaging);
        }
        public async Task<WebCustomerFeedbackViewModel> GetByStoreIdAsync(int id, int storeId)
        {
            var entity = await this.BaseService.GetActiveByStoreAsync(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new WebCustomerFeedbackViewModel(entity);
            }
        }

        public void RecordIsReadOnApi(int id, int storeId)
        {
            this.BaseService.RecordIsRead(id, storeId);
        }
    }
}
