using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmsService.ViewModels;
using SkyWeb.DatVM.Data;

namespace HmsService.Models.Entities.Services
{

    public enum ImageCollectionSortableProperty
    {
        Id,
        Name,

    }

    public partial interface IImageCollectionService
    {

        IQueryable<ImageCollection> GetByStoreId(int storeId);
        System.Threading.Tasks.Task UpdateAsync(ImageCollection entity, KeyValuePair<string, string>[] images);

        Task<ImageCollectionDetailsOfImages> GetActiveByStoreAsync(int id, int storeId);
        IQueryable<ImageCollectionDetailsOfImages> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty);
    }

    public partial class ImageCollectionService
    {

        public IQueryable<ImageCollection> GetByStoreId(int storeId)
        {
            return this.GetActive(q => q.StoreId == storeId);
        }

        public async Task<ImageCollectionDetailsOfImages> GetActiveByStoreAsync(int id, int storeId)
        {

            var imageCollection = await this.GetActive(q => q.Id == id && q.StoreId == storeId)
                .FirstOrDefaultAsync();
            if (imageCollection == null)
            {
                return null;
            }
            return new ImageCollectionDetailsOfImages
            {
                ImageCollection = imageCollection,
                Items = imageCollection.ImageCollectionItems.Where(a => a.Active)
            };
        }

        public async System.Threading.Tasks.Task UpdateAsync(ImageCollection entity, KeyValuePair<string, string>[] images)
        {
            // Images
            var items = entity.ImageCollectionItems.ToArray();
            items.UpdateList(images, (imageEntity, data, position, requireAddNew) =>
            {
                imageEntity.ImageUrl = data.Key;
                imageEntity.Title = data.Value;
                imageEntity.Position = position;
                if (requireAddNew)
                {
                    entity.ImageCollectionItems.Add(imageEntity);
                }
            });

            await this.UpdateAsync(entity);
        }

        public IQueryable<ImageCollectionDetailsOfImages> GetAdminByStoreWithFilter(int storeId, string keyword, KeyValuePair<string, bool> orderByProperty)
        {

            var result = this.GetActive(q =>
                q.StoreId == storeId &&
                (keyword == null || q.Name.Contains(keyword)));

            ImageCollectionSortableProperty name;
            if (orderByProperty.Key != null && Enum.TryParse(orderByProperty.Key, out name))
            {
                switch (name)
                {
                    case ImageCollectionSortableProperty.Id:
                        result = result.OrderBy(q => q.Id, orderByProperty.Value);
                        break;
                    case ImageCollectionSortableProperty.Name:
                        result = result.OrderBy(q => q.Name, orderByProperty.Value);
                        break;
                }
            }
            else
            {
                result = result.OrderBy(q => q.Id);
            }

            return result.Select(q => new ImageCollectionDetailsOfImages
            {
                ImageCollection = q,
                Items = q.ImageCollectionItems.Where(p => p.Active)
            });
        }

    }

    public class ImageCollectionDetailsOfImages : IEntity
    {
        public ImageCollection ImageCollection { get; set; }
        public IEnumerable<ImageCollectionItem> Items { get; set; }
    }

    public enum ImageCollectionSortablePropertyOfImage
    {
        Id,
        Name,

    }
}
