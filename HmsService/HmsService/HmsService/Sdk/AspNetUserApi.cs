using AutoMapper.QueryableExtensions;
using HmsService.Models.Entities;
using HmsService.Models.Entities.Services;
using HmsService.ViewModels;
using SkyWeb.DatVM.Mvc;
using SkyWeb.DatVM.Mvc.Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Sdk
{

    public partial class AspNetUserApi
    { 
        public IEnumerable<AspNetUser> GetAllAdmin()
        {
            return this.BaseService.Get(u => u.AspNetRoles.Any(r => r.Name.Equals("Admin"))).ToList();
        }

        public void DeleteUser(AspNetUser user)
        {
            var curUser = this.BaseService.FirstOrDefault(u => u.Id == user.Id);
            this.BaseService.Delete(curUser);
            this.BaseService.Save();
        }

        public void UpdateUser(AspNetUser user)
        {
            var curUser = this.BaseService.FirstOrDefault(u => u.Id == user.Id);
            curUser.Email = user.Email;
            curUser.PhoneNumber = user.PhoneNumber;
            this.BaseService.Save();
        }
    }

}
