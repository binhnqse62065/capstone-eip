using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HmsService.Models.Entities;
using HmsService.Models.Entities.Services;
using SkyWeb.DatVM.Mvc;

namespace HmsService.ViewModels
{
    public class ImageCollectionDetailsViewModel : BaseEntityViewModel<ImageCollectionDetailsOfImages>
    {
        public ImageCollectionViewModel ImageCollection { get; set; }
        public IEnumerable<ImageCollectionItemViewModel> Items { get; set; }
        public int NumberOfImage
        {
            get
            {
                return Items?.Count() ?? 0;
            }
        }

        public string Name
        {
            get
            {
                return ImageCollection.Name;
            }
        }
        public ImageCollectionDetailsViewModel() : base() { }
        public ImageCollectionDetailsViewModel(ImageCollectionDetailsOfImages entity) : base(entity) { }


        public ImageCollectionDetailsViewModel(ImageCollectionDetailsViewModel original, IMapper mapper) : this()
        {
            mapper.Map(original, this);
        }
    }
    public class ImageCollectionTreeViewModel: SkyWeb.DatVM.Mvc.BaseEntityViewModel<ImageCollection>
    {
        public ImageCollectionTreeViewModel() : base() { }
        public ImageCollectionTreeViewModel(ImageCollection entity):base(entity)
        {
            
        }
        public IEnumerable<ImageCollectionSubTreeViewModel> ImageSubCollection { get; set; }
    }
    public class ImageCollectionSubTreeViewModel : SkyWeb.DatVM.Mvc.BaseEntityViewModel<ImageCollection>
    {
        public ImageCollectionSubTreeViewModel() : base() { }
        public ImageCollectionSubTreeViewModel(ImageCollection entity):base(entity){ }

        public string ImageLink { get; set; }
        public string Title { get; set; }
        public string Title_EN { get; set; }
        public Nullable<int> Position { get; set; }
        public int Id { get; set; }
        public IEnumerable<ImageCollectionItemViewModel> ImageCollectionItemsInSub { get; set; }
    }
}
