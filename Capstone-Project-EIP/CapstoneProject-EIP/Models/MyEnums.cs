using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject_EIP.Models
{
    public class MyEnums
    {
        public enum CollectionType
        {
            [Display(Name = "Sponsor")]
            Sponsor = 3,
            [Display(Name = "Speaker")]
            Speaker = 2,
            [Display(Name = "File")]
            File = 4
        }
    }
}