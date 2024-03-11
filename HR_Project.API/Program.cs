using HR_Project.Application;
using HR_Project.Domain.Entitites.Common;
using HR_Project.Persistence;
using HR_Project.Persistence.Context;
using HR_Project.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HR_Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HRProjectAPIDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Tarik")));

            builder.Services.AddPersistenceServices(); // bu kod repolar� servisleri falan tek yerden ioc olarak kullanmam�z� sagl�yo bunun i�ini de persistence katman�ndaki serviceregistration da dolduruyoruz


            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<HRProjectAPIDBContext>();

            builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");

            builder.Services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            });






            //REPOS�TOR�ES
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddTransient<ISiteManagerRepository, SiteManagerRepository>();



            //builder.Services.AddTransient<ISiteManagerService, SiteManagerService>();








            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
               options.AddPolicy("AllowSpecificOrigin",
                   builder =>
                   {
                       builder.WithOrigins("https://localhost:5173") // �zin vermek istedi�iniz kaynak
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                   });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}