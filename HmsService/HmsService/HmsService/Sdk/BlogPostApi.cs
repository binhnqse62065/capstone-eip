using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class BlogPostApi
    {
        public async Task<BlogPostViewModel> GetBlogPostBySeoNameAsync(string seoName, int storeId)
        {
            var entity = await this.BaseService.GetActive(q => q.SeoName == seoName && q.StoreId == storeId)
               .FirstOrDefaultAsync();
            var blogPost = new BlogPostViewModel(entity);
            return blogPost;
        }

        public IEnumerable<BlogPost> GetPromotionWithEventStart(int storeId, int collectionId)
        {
            return this.BaseService.Get(q => q.Active && q.StoreId == storeId && q.BlogCategoryId == collectionId);
        }

        public IEnumerable<BlogPost> GetTwoCollectionNews(int storeId)
        {
            var plus = new List<BlogPost>();
            var collectionNewsWedding =  this.BaseService.Get(q => q.Active && q.StoreId == storeId && q.BlogCategoryId == 1).ToList();// Tin tức tiệc cưới
            var collectionNewsConvention =  this.BaseService.Get(q => q.Active && q.StoreId == storeId && q.BlogCategoryId == 4).ToList(); // Tin tức hội nghị
            if (collectionNewsWedding == null && collectionNewsConvention == null)
            {
                return null;
            }
            if (collectionNewsConvention == null)
            {
                plus = collectionNewsWedding;
            }
            else if (collectionNewsWedding == null)
            {
                plus = collectionNewsConvention;
            }else
            {
                collectionNewsWedding.AddRange(collectionNewsConvention);
                plus = collectionNewsWedding;
            }
            
            var number = plus.Count;
            var random = new System.Random();
            List<BlogPost> result = new List<BlogPost>();
            var limit = 9;
            if (limit > number)
            {
                limit = number;
            }
            for (int i = 0; i < limit; i++) // 6 bài viết
            {
                var at = random.Next(0, plus.Count - 1);
                result.Add(plus.ElementAt(at));
                plus.RemoveAt(at);
            }

            return result.AsEnumerable();
        }


        public IEnumerable<BlogPost> GetBlogPostRandomByCateId(int collectionId, int storeId)
        {
            var list= this.BaseService.GetActive(q => q.Active && q.StoreId == storeId && q.BlogCategoryId == collectionId).ToList();
            var number = list.Count;
            var random = new System.Random();
            List<BlogPost> result = new List<BlogPost>();
            var limit = 6;
            if (limit > number)
            {
                limit = number;
            }
            for (int i = 0; i < limit; i++) // 6 bài viết
            {
                var at = random.Next(0, list.Count - 1);
                result.Add(list.ElementAt(at));
                list.RemoveAt(at);
            }
            return result.AsEnumerable();
        }

        public async Task<BlogPost> GetActiveByStoreAsync(int id, int storeId)
        {
            return await this.BaseService.FirstOrDefaultAsync(q => q.Id == id && q.StoreId == storeId);
        }

        public List<BlogPost> GetTopBlogDisplayByCate(int categoryId, int top)
        {
            int status = (int)BlogStatusEnum.Approve;
            var allBlog = this.BaseService.Get(q => q.BlogCategoryId == categoryId && q.Status == status).OrderBy(q => q.Position);
            allBlog = allBlog.Take(top).OrderBy(q => q.CreatedTime);
            return allBlog.ToList();
        }
        // GetBlogWithSixItemsForOnepage
        public IEnumerable<BlogPost> GetBlogWithSixItemsForOnepage(int number, int collectionId)
        {
            return this.BaseService.GetBlogWithSixItemsForOnepage(number, collectionId);
        }

        public string StatusOfReturnPage(int number, int collectionId)
        {
            return this.BaseService.StatusOfReturnPage(number, collectionId);
        }

        public List<BlogPost> GetContinuteBlogDisplayByCate(int categoryId, int skip, int take)
        {
            int status = (int)BlogStatusEnum.Approve;
            var allBlog = this.BaseService.Get(q => q.BlogCategoryId == categoryId && q.Status == status).OrderBy(q => q.Position);
            allBlog = allBlog.Skip(skip).Take(take).OrderBy(q => q.CreatedTime);
            return allBlog.ToList();
        }
        public async Task<BlogPostDetailsViewModel> GetDetailsByStoreIdAsync(int id, int storeId)
        {
            var entity = await this.BaseService.GetActiveDetailsByStoreAsync(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BlogPostDetailsViewModel(entity);
            }
        }

        public BlogPost GetDetailBlog(int blogId)
        {
            return this.BaseService.Get(blogId);
        }
        /// <summary>
        /// Get Id Blog by SEO
        /// </summary>
        /// <param name="seoName"></param>
        /// <returns> Value Id of Blog; return -1 When Not Found;</returns>
        public int GetIdPostBySeoName(string seoName, int storeId)
        {
            var blog = this.BaseService.FirstOrDefault(q => q.SeoName == seoName && storeId == q.StoreId);
            if (blog != null)
            {
                return blog.Id;
            }
            else
            {
                return -1;
            }
        }

        public int GetIdPostBySeoNameAndType(string seoName, int storeId, int type)
        {
            var blog = this.BaseService.FirstOrDefault(q => q.SeoName == seoName && storeId == q.StoreId && type == q.BlogType);
            if (blog != null)
            {
                return blog.Id;
            }
            else
            {
                return -1;
            }
        }

        public List<ReferenceLink> GetLinkReference(int blogId)
        {
            var listResult = new List<ReferenceLink>();
            var blog = this.BaseService.Get(blogId);
            if (blog != null)
            {
                if (blog.LinkRef1 != null)
                {
                    var tempRef = new ReferenceLink();
                    var blogtmp = this.BaseService.Get(blog.LinkRef1);
                    if (blogtmp != null)
                    {
                        tempRef.linkAccess = Utils.GetFullPathBlohBaseOnSEOName(blogtmp);
                        tempRef.tile = blogtmp.Title;
                        listResult.Add(tempRef);
                    }
                }

                if (blog.LinkRef2 != null)
                {
                    var tempRef = new ReferenceLink();
                    var blogtmp = this.BaseService.Get(blog.LinkRef1);
                    if (blogtmp != null)
                    {
                        tempRef.linkAccess = Utils.GetFullPathBlohBaseOnSEOName(blogtmp);
                        tempRef.tile = blogtmp.Title;
                        listResult.Add(tempRef);
                    }
                }
                if (blog.LinkRef3 != null)
                {
                    var tempRef = new ReferenceLink();
                    var blogtmp = this.BaseService.Get(blog.LinkRef1);
                    if (blogtmp != null)
                    {
                        tempRef.linkAccess = Utils.GetFullPathBlohBaseOnSEOName(blogtmp);
                        tempRef.tile = blogtmp.Title;
                        listResult.Add(tempRef);
                    }
                }
                if (blog.LinkRef4 != null)
                {
                    var tempRef = new ReferenceLink();
                    var blogtmp = this.BaseService.Get(blog.LinkRef1);
                    if (blogtmp != null)
                    {
                        tempRef.linkAccess = Utils.GetFullPathBlohBaseOnSEOName(blogtmp);
                        tempRef.tile = blogtmp.Title;
                        listResult.Add(tempRef);
                    }
                }
                if (blog.LinkRef5 != null)
                {
                    var tempRef = new ReferenceLink();
                    var blogtmp = this.BaseService.Get(blog.LinkRef1);
                    if (blogtmp != null)
                    {
                        tempRef.linkAccess = Utils.GetFullPathBlohBaseOnSEOName(blogtmp);
                        tempRef.tile = blogtmp.Title;
                        listResult.Add(tempRef);
                    }
                }
            }
            return listResult;
        }
        public IEnumerable<BlogPost> GetBlogPostByCategoryId(int storeId, int cateId)
        {
            return this.BaseService.Get(q => q.StoreId == storeId && q.Active && q.BlogCategoryId == cateId).AsEnumerable();
        }

        public PagingViewModel<BlogPostDetailsViewModel> GetAdminWithFilterAsync(int storeId, string keyword, int currPage, int pageSize, KeyValuePair<string, bool> sortKeyAsc, int filterCateId)
        {
            var pagedList = this.BaseService.GetAdminByStoreWithFilter(storeId, keyword, sortKeyAsc, filterCateId)
                .ProjectTo<BlogPostDetailsViewModel>(this.AutoMapperConfig);

            var afterPaging = pagedList.Page(currPage, pageSize);

            return new PagingViewModel<BlogPostDetailsViewModel>(afterPaging);
        }

        public async Task EditAsync(BlogPostViewModel model)
        {
            model = Utils.ToExactType<BlogPostViewModel, BlogPostViewModel>(model);

            var entity = await this.BaseService.GetAsync(model.Id);
            model.CopyToEntity(entity);

            this.BaseService.Update(entity);
        }
        public async Task CreateBlogPostAsync(BlogPostViewModel model)
        {
            model = Utils.ToExactType<BlogPostViewModel, BlogPostViewModel>(model);

            var entity = model.ToEntity();

            await this.BaseService.CreateBlogPostAsync(entity);
        }

        public IEnumerable<BlogPost> GetHotBlogWithSixItems(int categoryId, int storeId)
        {
            var res = this.BaseService.Get(q => q.Active && q.StoreId == storeId && q.IsHotNews && q.BlogCategoryId == categoryId);
            if (res.Count()>=6)
            {
                res = res.Take(6);
            }
            return res.AsEnumerable();
        }
    }
}
