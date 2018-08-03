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
    public partial class CollectionTypeApi
    {
        public IEnumerable<CollectionTypeViewModel> GetCollectionType()
        {
            return this.BaseService.Get(c => c.IsActive == true).ProjectTo<CollectionTypeViewModel>(this.AutoMapperConfig).ToList();
        }

        public int AddNewCollectionType(string collectionTypeName)
        {
            CollectionType collectionType = new CollectionType
            {
                IsActive = true,
                Name = collectionTypeName
            };
            this.BaseService.Create(collectionType);
            this.BaseService.Save();
            return collectionType.CollectionTypeID;
        }

        public bool UpdateCollectionType(CollectionType collectionType)
        {
            var collectionTypeUp = this.BaseService.FirstOrDefault(c => c.CollectionTypeID == collectionType.CollectionTypeID);
            collectionTypeUp.Name = collectionType.Name;
            //collectionTypeUp.Description = collectionType.Description;
            this.BaseService.Save();
            return true;
        }

        public bool DeleteCollectionType(CollectionType collectionType)
        {
            var collectionDel = this.BaseService.FirstOrDefault(c => c.CollectionTypeID == collectionType.CollectionTypeID);
            this.BaseService.Delete(collectionDel);
            this.BaseService.Save();
            return true;
        }

       
    }
}
