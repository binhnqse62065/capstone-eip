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
       
    }
}
