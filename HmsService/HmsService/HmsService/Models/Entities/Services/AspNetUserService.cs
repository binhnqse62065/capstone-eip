using HmsService.Models.Entities.Repositories;
using SkyWeb.DatVM.Data;
using SkyWeb.DatVM.Mvc.Autofac;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models.Entities.Services
{

    public partial interface IAspNetUserService
    {
        
    }

    public partial class AspNetUserService
    {

    }

    public class AspNetUserDetails : IEntity
    {

        public AspNetUser AspNetUser { get; set; }
        public ICollection<AspNetRole> Roles { get; set; }
       

    }

}
