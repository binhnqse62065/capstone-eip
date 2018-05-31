using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IBlogCategoryService
    {
        IQueryable<BlogCategory> GetAllBlogCategoryActiveByStoreId(int storeId);
    }
    public partial class BlogCategoryService
    {
        public IQueryable<BlogCategory> GetAllBlogCategoryActiveByStoreId(int storeId)
        {
            return this.Get(q => q.IsActive && q.StoreId == storeId && q.IsDisplay == true );
        }
    }
}
