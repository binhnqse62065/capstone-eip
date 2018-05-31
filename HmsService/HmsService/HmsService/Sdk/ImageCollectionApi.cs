using HmsService.ViewModels;
using System;
using System.Collections.Generic;
using SkyWeb.DatVM.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using HmsService.Models.Entities;
using HmsService.Models;

namespace HmsService.Sdk
{
    public partial class ImageCollectionApi
    {
        public async Task<IEnumerable<ImageCollectionViewModel>> GetByStoreIdAsync(int storeId)
        {
            return await this.BaseService.GetByStoreId(storeId)
                .ProjectTo<ImageCollectionViewModel>(this.AutoMapperConfig)
                .ToListAsync();
        }

        public IQueryable<ImageCollection> GetAllByStoreId(int storeId, int brandId)
        {
            if (storeId <= 0)
            {
                var storeApi = new StoreApi();
                var listStoreID = storeApi.GetActiveStoreByBrandId(brandId).Select(q => q.ID);
                return this.BaseService.GetActive(q => listStoreID.Contains(q.StoreId)).OrderBy(p => p.Position);
            }
            else
            {
                return this.BaseService.Get(q => q.StoreId == storeId && q.Active == true).OrderBy(p => p.Position);
            }
        }

        public async Task EditAsync(ImageCollectionViewModel model, IEnumerable<ImageCollectionItemViewModel> items)
        {

            model = Utils.ToExactType<ImageCollectionViewModel, ImageCollectionViewModel>(model);

            var entity = await this.BaseService.GetAsync(model.Id);

            await this.BaseService.UpdateAsync(entity, items.Select(a => new KeyValuePair<string, string>(a.ImageUrl, a.Title)).ToArray());
        }

        public async Task<ImageCollectionDetailsViewModel> GetByStoreIdAsync(int id, int storeId)
        {
            var entity = await this.BaseService.GetActiveByStoreAsync(id, storeId);

            if (entity == null)
            {
                return null;
            }
            else
            {
                return new ImageCollectionDetailsViewModel(entity);
            }
        }

        public PagingViewModel<ImageCollectionDetailsViewModel> GetAdminWithFilter(int storeId, string keyword,
            int currPage, int pageSize, KeyValuePair<string, bool> sortKeyAsc)
        {

            var pagedList = this.BaseService.GetAdminByStoreWithFilter(storeId, keyword, sortKeyAsc)
                .ProjectTo<ImageCollectionDetailsViewModel>(this.AutoMapperConfig)
                .Page(currPage, pageSize);

            return new PagingViewModel<ImageCollectionDetailsViewModel>(pagedList);
        }

        public void CreateImageCollection(ImageCollectionViewModel model)
        {
            model = Utils.ToExactType<ImageCollectionViewModel, ImageCollectionViewModel>(model);

            var entity = model.ToEntity();

            this.BaseService.Create(entity);
        }

        public ImageCollectionTreeViewModel GetImageCollectionsByParentId(int parentId)
        {
            var entity = this.BaseService.Get(q => q.Active && q.Id == parentId).FirstOrDefault();
            var viewModel = new ImageCollectionTreeViewModel(entity);
            List<ImageCollectionSubTreeViewModel> subCollection = new List<ImageCollectionSubTreeViewModel>();

            if (entity.ImageCollection1 != null && entity.ImageCollection1.Count > 0)
            {
                foreach (var item in entity.ImageCollection1)
                {
                    if (item.Active)
                    {
                        var subCollectionItem = new ImageCollectionSubTreeViewModel();
                        var subItems = item.ImageCollectionItems;
                        subCollectionItem.ImageLink = item.ImageLink;
                        subCollectionItem.Title = item.Name;
                        subCollectionItem.Title_EN = item.Name_En;
                        subCollectionItem.Position = item.Position;
                        subCollectionItem.Id = item.Id;

                        List<ImageCollectionItemViewModel> itemsInCollection = new List<ImageCollectionItemViewModel>();
                        if (subItems != null && subItems.Count() > 0)
                        {
                            foreach (var itemInCollection in subItems)
                            {
                                //do không biết auto mapper + thời gian gấp nên làm bằng tay
                                var image = new ImageCollectionItemViewModel()
                                {
                                    Id = itemInCollection.Id,
                                    Active = itemInCollection.Active,
                                    Description = itemInCollection.Description,
                                    DescriptionEng = itemInCollection.DescriptionEng,
                                    Title = itemInCollection.Title,
                                    TitleEng = itemInCollection.TitleEng,
                                    Position = itemInCollection.Position,
                                    ImageCollectionId = itemInCollection.ImageCollectionId,
                                    ImageUrl = itemInCollection.ImageUrl,
                                    Link = itemInCollection.Link,
                                };
                                itemsInCollection.Add(image);
                            }
                        }
                        subCollectionItem.ImageCollectionItemsInSub = itemsInCollection;
                        subCollection.Add(subCollectionItem);
                    }
                }
            }


            viewModel.ImageSubCollection = subCollection;
            return viewModel;
        }

        public IEnumerable<ImageCollectionSubTreeViewModel> GetHotImageCollection()
        {
            // dành cho Hình ảnh hội nghi, hình ảnh tiệc cưới
            var result = this.BaseService.GetActive(q => (q.ParentId == 75 || q.ParentId == 76)&& q.HotCollection); // Id cứng của image collection

            List<ImageCollectionSubTreeViewModel> subCollection = new List<ImageCollectionSubTreeViewModel>();

            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    if (item.Active)
                    {
                        var subCollectionItem = new ImageCollectionSubTreeViewModel();
                        var subItems = item.ImageCollectionItems;
                        subCollectionItem.ImageLink = item.ImageLink;
                        subCollectionItem.Title = item.Name;
                        subCollectionItem.Title_EN = item.Name_En;
                        subCollectionItem.Position = item.Position;
                        subCollectionItem.Id = item.Id;

                        List<ImageCollectionItemViewModel> itemsInCollection = new List<ImageCollectionItemViewModel>();
                        if (subItems != null && subItems.Count() > 0)
                        {
                            foreach (var itemInCollection in subItems)
                            {
                                //do không biết auto mapper + thời gian gấp nên làm bằng tay
                                var image = new ImageCollectionItemViewModel()
                                {
                                    Id = itemInCollection.Id,
                                    Active = itemInCollection.Active,
                                    Description = itemInCollection.Description,
                                    DescriptionEng = itemInCollection.DescriptionEng,
                                    Title = itemInCollection.Title,
                                    TitleEng = itemInCollection.TitleEng,
                                    Position = itemInCollection.Position,
                                    ImageCollectionId = itemInCollection.ImageCollectionId,
                                    ImageUrl = itemInCollection.ImageUrl,
                                    Link = itemInCollection.Link,
                                };
                                itemsInCollection.Add(image);
                            }
                        }
                        subCollectionItem.ImageCollectionItemsInSub = itemsInCollection;
                        subCollection.Add(subCollectionItem);
                    }
                }
            }
            var reScale = subCollection.OrderBy(q => q.Position).ToList();
            if (reScale.Count() > 12)
            {
                reScale = reScale.Take(12).ToList(); ;
            }

            return reScale.AsEnumerable();
        }
    }
}
