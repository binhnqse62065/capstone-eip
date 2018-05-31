using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class ImageCollectionItemApi
    {
        public IEnumerable<ImageCollectionItem> GetItemsByCollectionId(int collectionId)
        {
            var res = this.BaseService.Get(q => q.ImageCollectionId == collectionId && q.Active);
            return res.AsEnumerable();
        }

        
    }
}
