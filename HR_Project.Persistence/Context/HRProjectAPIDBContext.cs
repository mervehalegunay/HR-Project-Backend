﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HR_Project.Domain.Entitites;
using HR_Project.Domain.Entitites.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HR_Project.Persistence.Context
{
    public class HRProjectAPIDBContext : IdentityDbContext<AppUser>
    {
        public HRProjectAPIDBContext(DbContextOptions<HRProjectAPIDBContext> options) : base(options)
        {


        }

        // public DbSet<Employee> Employees { get; set; }
        // public DbSet<Department> Departments { get; set; }
        // public DbSet<Job> Jobs { get; set; }
        // public DbSet<Company> Companies { get; set; }
        // public DbSet<Spend> Spends { get; set; }
        // public DbSet<Leave> Leaves { get; set; }
        // public DbSet<Advance> Advances { get; set; }
        // public DbSet<Director> Directors { get; set; }
        public DbSet<SiteManager> SiteManagers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<SiteManager>().HasData(new SiteManager {Id=-1, AppUserId= Guid.NewGuid().ToString(), FirstName="hale", LastName="gny", BirthDate=DateTime.Now, HireDate=DateTime.Today, TCNO="11111111111111", BirthPlace="Beykoz",PhoneNumber="5553332211", City="İst", District="Marmara", AddressDetail="yakını", Salary=100000});
            base.OnModelCreating(builder);
        }


    }
}
