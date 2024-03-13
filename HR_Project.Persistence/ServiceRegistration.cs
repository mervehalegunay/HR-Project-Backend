using HR_Project.Application;
using HR_Project.Application.Services;
using HR_Project.Persistence.Context;
using HR_Project.Persistence.Repositories;
using HR_Project.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            // Connection string'i al
            var connectionString = configuration.GetConnectionString("Tarik"); // veya istediğiniz anahtar

            // SQL Server bağlantısını ekle
            services.AddDbContext<HRProjectAPIDBContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ISiteManagerRepository, SiteManagerRepository>();
            services.AddScoped<ISiteManagerService, SiteManagerService>();
        }
        
           
    }
}
