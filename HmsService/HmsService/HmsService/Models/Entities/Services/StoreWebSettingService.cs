using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IStoreWebSettingService
    {
        Task MassUpdate(IEnumerable<KeyValuePair<int, string>> values, int storeId);
    }

    partial class StoreWebSettingService
    {
        public async System.Threading.Tasks.Task MassUpdate(IEnumerable<KeyValuePair<int, string>> values, int storeId)
        {
            foreach (var value in values)
            {
                var entity = await this.GetAsync(value.Key);

                if (entity.StoreId != storeId || !entity.Active)
                {
                    throw new UnauthorizedAccessException();
                }

                entity.Value = value.Value;
            }

            await this.SaveAsync();
        }
    }
}
