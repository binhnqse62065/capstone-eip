using AutoMapper.QueryableExtensions;
using HmsService.Models;
using HmsService.Models.Entities;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HmsService.Sdk;

namespace HmsService.Sdk
{
    public partial class CollectionItemApi
    {
        public int AddNewCollectionItem(CollectionItem collectionItem)
        {
            this.BaseService.Create(collectionItem);
            this.BaseService.Save();
            return collectionItem.CollectionItemID;
        }
       
        public void DeleteCollectionItem(CollectionItem collectionItem)
        {
            var curItem = this.BaseService.FirstOrDefault(i => i.CollectionItemID == collectionItem.CollectionItemID);
            this.BaseService.Delete(curItem);
            this.BaseService.Save();
        }

        public void UpdateCollectionItem(CollectionItem collectionItem)
        {
            var curItem = this.BaseService.FirstOrDefault(i => i.CollectionItemID == collectionItem.CollectionItemID);
            curItem.Name = collectionItem.Name;
            curItem.Description = collectionItem.Description;
            curItem.ImageUrl = collectionItem.ImageUrl;
            this.BaseService.Save();
        }
    }
}
