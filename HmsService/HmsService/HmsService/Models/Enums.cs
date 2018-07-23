﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models
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

