using HmsService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{
    public partial class TagApi
    {
        public List<Tag> GetAllTagByBlog(int blogId)
        {
            var tagMappingApi = new TagMappingApi();
            var mapping = tagMappingApi.GetAllMappingByBlogId(blogId).AsEnumerable();
            var tags = this.BaseService.Get().AsEnumerable();
            var jointable = from t1 in mapping
                            join t2 in tags
                       on t1.TagId equals t2.Id
                            select t2;
            return jointable.ToList();
        }

        public List<Tag> GetAllTagByBlogCate(int blogCateId)
        {
            var tagMappingApi = new TagMappingApi();
            var mapping = tagMappingApi.GetAllMappingByBlogCateId(blogCateId).AsEnumerable();
            var tags = this.BaseService.Get().AsEnumerable();
            var jointable = from t1 in mapping
                            join t2 in tags
                       on t1.TagId equals t2.Id
                            select t2;
            return jointable.ToList();
        }
    }
}
