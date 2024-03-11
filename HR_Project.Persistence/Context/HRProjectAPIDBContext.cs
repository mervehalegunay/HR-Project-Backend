using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HR_Project.Domain.Entitites;
using HR_Project.Domain.Entitites.Common;
using Microsoft.AspNetCore.Identity;
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
     
        public DbSet<SiteManager> SiteManagers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
			const string adminId = "df5a9b38-18e8-48b7-97bf-ad4a9b4afe0e";

			const string roleId = "f6040633-db1b-4a48-be54-9f214e77ac9d";

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = roleId,
				Name = "admin",
				NormalizedName = "ADMIN"
			},
			new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Standard User",
				NormalizedName = "STANDARD USER"
			}
			);

			var hasher = new PasswordHasher<AppUser>();
			builder.Entity<AppUser>().HasData(new AppUser
			{
				Id = adminId,
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				PasswordHash = hasher.HashPassword(null, "Admin123."),
				SecurityStamp = string.Empty,
				FirstName = "Admin",
				LastName = "Admin"
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				UserId = adminId,
				RoleId = roleId,
			});
            base.OnModelCreating(builder);
        }


    }
}
