using SkyWeb.DatVM.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{
    public partial interface IBlogPostService
    {
        Task<BlogPost> GetBlogPostBySeoNameAsync(string seoName, int storeId);
        IQueryable<BlogPost> GetByStoreId(int storeId);

        IQueryable<BlogPostDetails> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty, int filterCateId);
        Task<BlogPost> GetActiveByStoreAsync(int id, int storeId);
        BlogPost GetActiveByStore(int id, int storeId);
        IQueryable<BlogPostDetails> GetAllActiveByStoreId(int storeId);
        Task<BlogPostDetails> GetActiveDetailsByStoreAsync(int id, int storeId);
        Task<BlogPostDetails> GetActiveDetailsByStoreAsync(string seoname, int storeId);
        BlogPostDetails GetActiveDetailsByStore(int id, int storeId);
        System.Threading.Tasks.Task CreateBlogPostAsync(BlogPost entity);
        System.Threading.Tasks.Task UpdateBlogPostAsync(BlogPost entity);
        IQueryable<BlogPost> GetByCollectionId(int? collectionId);
        IEnumerable<BlogPost> GetBlogWithSixItemsForOnepage(int number, int collectionid);
        string StatusOfReturnPage(int number, int collectionId);
    }

    public partial class BlogPostService
    {
        public async Task<BlogPost> GetBlogPostBySeoNameAsync(string seoName, int storeId)
        {
            var blogPost = await this.GetActive(q => q.SeoName == seoName && q.StoreId == storeId)
                .FirstOrDefaultAsync();
            return blogPost;
        }

        public IQueryable<BlogPost> GetByStoreId(int storeId)
        {
            var blogPosts = this.Get(q => q.StoreId == storeId);
            return blogPosts;
        }

        public string StatusOfReturnPage(int number, int collectionId)
        {
            var status = "NormalPage";
            var res = this.Get(q => q.Active && q.BlogCategoryId == collectionId)
               .OrderByDescending(o => o.CreatedTime)
               .ThenByDescending(p => p.Position)
               .ToList();
            var numberOfBlog = res.Count();
            float perBlog = (numberOfBlog / (6*1.0f));
            int perRoundBlog = (numberOfBlog / 6);

            if (number == 0)
            {
                status = "StartPage";
            }

            if ((number + 1) == perRoundBlog && perBlog == (perRoundBlog * 1.0f))
            {
                status = "EndPage";
            }
            else if ((number + 1) > perRoundBlog && perBlog > (perRoundBlog * 1.0f))
            {
                status = "EndPage";
            }

            if (numberOfBlog <= 6)
            {
                status = "OnePage";
            }

            return status;
        }
        public IEnumerable<BlogPost> GetBlogWithSixItemsForOnepage(int number, int collectionId)
        {
            var res = this.Get(q => q.Active && q.BlogCategoryId == collectionId)
                .OrderByDescending(o => o.CreatedTime)
                .ThenByDescending(p => p.Position)
                .ToList();
            if (res == null || res.Count == 0)
            {
                return null;
            }
            var start = number * 6;
            var end = (number + 1) * 6;
            var numberOfBlog = res.Count();
            if (start > numberOfBlog)
            {
                return null;
            }
            if (numberOfBlog < end)
            {
                end = numberOfBlog;
            }
            if (start == numberOfBlog)
            {
                end = numberOfBlog + 1;
            }
            List<BlogPost> result = new List<BlogPost>();
            for (int i = start; i < end; i++)
            {
                result.Add(res.ElementAt(i));
            }
            return result.AsEnumerable();
        }

        public IQueryable<BlogPostDetails> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty, int filterCateId)
        {
            var entities = this.GetActive(q =>
                q.StoreId == storeId &&
                (keyword == null || q.Title.Contains(keyword)));

            if (filterCateId!=0)
            {
                entities = entities.Where(q => q.BlogCategoryId == filterCateId);
            }
            BlogPostSortableProperty name;
            if (orderByProperty.Key != null && Enum.TryParse(orderByProperty.Key, out name))
            {
                switch (name)
                {
                    case BlogPostSortableProperty.Id:
                        entities = entities.OrderBy(q => q.Id, orderByProperty.Value);
                        break;
                    case BlogPostSortableProperty.Title:
                        entities = entities.OrderBy(q => q.Title, orderByProperty.Value);
                        break;
                    case BlogPostSortableProperty.EventStart:
                        entities = entities.OrderBy(q => q.EventStart, orderByProperty.Value);
                        break;
                    case BlogPostSortableProperty.Collection:
                        entities = entities.OrderBy(q => q.BlogCategoryId, orderByProperty.Value);
                        break;
                }
            }
            else
            {
                entities = entities.OrderByDescending(q => q.EventStart).ThenBy(o=>o.Position);
            }

            var result = entities.Select(q => new BlogPostDetails()
            {
                BlogPost = q,
                BlogPostCollections = q.BlogPostCollectionItemMappings.AsQueryable()
                    .Where(p => p.Active && p.BlogPostCollection.Active)
                    .Select(p => p.BlogPostCollection),
                BlogPostImages = q.BlogPostImages.AsQueryable()
                        .Where(sq => sq.Active),
                BlogCategoryId = q.BlogCategoryId.Value,
            });

            return result;
        }

        public override void Create(BlogPost entity)
        {
            this.repository.Add(entity);
            this.Save();
        }

        public async Task<BlogPost> GetActiveByStoreAsync(int id, int storeId)
        {
            return await this.FirstOrDefaultActiveAsync(q => q.Id == id && q.StoreId == storeId);
        }

        public BlogPost GetActiveByStore(int id, int storeId)
        {
            return this.FirstOrDefaultActive(q => q.Id == id && q.StoreId == storeId);
        }
        public IQueryable<BlogPostDetails> GetAllActiveByStoreId(int storeId)
        {
            return this.Get(q => q.StoreId == storeId && q.Active == true).Select(b => new BlogPostDetails()
            {
                BlogPost = b,
                BlogPostCollections = b.BlogPostCollectionItemMappings.AsQueryable()
                    .Where(p => p.Active && p.BlogPostCollection.Active && p.BlogPostId == b.Id)
                    .Select(p => p.BlogPostCollection),
                //BlogPostImages = b.BlogPostImages.AsQueryable()
                //        .Where(sq => sq.Active)
            });
        }

        public async Task<BlogPostDetails> GetActiveDetailsByStoreAsync(string seoname, int storeId)
        {
            var entity = await this.GetActive(a => a.SeoName.Equals(seoname) && storeId == a.StoreId)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BlogPostDetails()
                {
                    BlogPost = entity,
                    BlogPostCollections = entity.BlogPostCollectionItemMappings.AsQueryable()
                        .Where(q => q.Active && q.BlogPostCollection.Active)
                        .Select(q => q.BlogPostCollection),
                    BlogPostImages = entity.BlogPostImages.AsQueryable()
                        .Where(q => q.Active)
                };
            }
        }
        public async Task<BlogPostDetails> GetActiveDetailsByStoreAsync(int id, int storeId)
        {
            var entity = await this.GetActiveByStoreAsync(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BlogPostDetails()
                {
                    BlogPost = entity,
                    BlogPostCollections = entity.BlogPostCollectionItemMappings.AsQueryable()
                        .Where(q => q.Active && q.BlogPostCollection.Active)
                        .Select(q => q.BlogPostCollection),
                    BlogPostImages = entity.BlogPostImages.AsQueryable()
                        .Where(q => q.Active)
                };
            }
        }
        public BlogPostDetails GetActiveDetailsByStore(int id, int storeId)
        {
            var entity = this.GetActiveByStore(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new BlogPostDetails()
                {
                    BlogPost = entity,
                    BlogPostCollections = entity.BlogPostCollectionItemMappings.AsQueryable()
                        .Where(q => q.Active && q.BlogPostCollection.Active)
                        .Select(q => q.BlogPostCollection),
                    BlogPostImages = entity.BlogPostImages.AsQueryable()
                        .Where(q => q.Active)
                };
            }
        }
        public async System.Threading.Tasks.Task CreateBlogPostAsync(BlogPost entity)
        {
            await this.CreateAsync(entity);
        }

        public async System.Threading.Tasks.Task UpdateBlogPostAsync(BlogPost entity)
        {
            await this.UpdateAsync(entity);
        }
        public IQueryable<BlogPost> GetByCollectionId(int? collectionId)
        {
            var rs = this.GetActive(q => q.BlogPostCollectionItemMappings.Any(a => a.BlogPostCollectionId == collectionId));
            return rs;
        }


        //HiepBP-PhuongTA
        //public IQueryable<BlogPost> GetByCollectionId(int? collectionId)
        //{
        //    var rs = this.GetActive(q => q.BlogPostCollectionItems.Any(a => a.BlogPostCollectionId == collectionId));
        //    return rs;
        //}

    }

    public class BlogPostDetails : IEntity
    {
        public BlogPost BlogPost { get; set; }
        public IQueryable<BlogPostCollection> BlogPostCollections { get; set; }
        public IEnumerable<BlogPostImage> BlogPostImages { get; set; }

        public int BlogCategoryId { get; set; }
    }

    public enum BlogPostSortableProperty
    {
        Id,
        Title,
        EventStart,
        Collection,
    }

}
