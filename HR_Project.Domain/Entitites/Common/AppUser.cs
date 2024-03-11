using HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entitites.Common
{
    public class AppUser : IdentityUser
    {
       
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool isDeleted { get; set; }
        public Status Status { get; set; } = Status.Active;
       

    }
}
