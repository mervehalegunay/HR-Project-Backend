﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Aktif")]
        Active = 1,


        [Display(Name = "Güncellendi")]
        Modified,


        [Display(Name = "Pasif")]
        Passive
    }
}
