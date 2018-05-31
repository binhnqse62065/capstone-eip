using HmsService.Models.Entities.Services;
using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using HmsService.Models.Entities;

namespace HmsService.Sdk
{
    public partial class BlogCategoryApi
    {
        public List<BlogCategoryViewModel> GetAllBlogCategoryActiveByStoreId(int storeId)
        {
            var result = this.BaseService.GetAllBlogCategoryActiveByStoreId(storeId)
                .ProjectTo<BlogCategoryViewModel>(this.AutoMapperConfig)
                .ToList();
            return result;
        }

        public IQueryable<BlogCategory> GetAllBlogCategoryActive()
        {
            return this.BaseService.Get(q=> q.IsActive == true);
        }

        public IQueryable<BlogCategory> GetParrentCategory(int brandId)
        {
            return this.BaseService.Get(q => q.BrandId == brandId && q.BlogCategory1.Count > 0);
        }

        public int GetIdCateBySeoName(string seoName, int storeId)
        {
            var cate = this.BaseService.FirstOrDefault(q => q.SeoName == seoName && q.StoreId == storeId);
            if (cate != null)
            {
                return cate.Id;
            } else
            {
                return -1;
            }
        }

        public int DetectPath(string seoName, int storeId, int type)
        {
            var cate = this.BaseService.FirstOrDefault(q => q.SeoName == seoName && q.StoreId == storeId && q.Type == type);
            if (cate != null)
            {
                return cate.Id;
            }
            else
            {
                return -1;
            }
        }

    }
}
