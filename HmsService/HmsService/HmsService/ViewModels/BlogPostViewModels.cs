using HmsService.Models.Entities.Services;
using SkyWeb.DatVM.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.ViewModels
{

    public class BlogPostDetailsViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<BlogPostDetails>
    {

        public BlogPostViewModel BlogPost { get; set; }
        public IEnumerable<BlogPostCollectionViewModel> BlogPostCollections { get; set; }
        public IEnumerable<BlogPostImageViewModel> BlogPostImages { get; set; }
        public int BlogCategoryId { get; set; }

        public BlogPostDetailsViewModel() : base() { }
        public BlogPostDetailsViewModel(BlogPostDetails entity) : base(entity) { }

    }

}
