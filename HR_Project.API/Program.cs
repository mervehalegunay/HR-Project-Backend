using HR_Project.Application;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites.Common;
using HR_Project.Persistence.Context;
using HR_Project.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HR_Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<ISiteManagerRepository , SiteManagerRepository>();

            // builder.Services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            

            
            
            builder.Services.AddTransient<SiteManagerService>();




            // Add services to the container.


            builder.Services.AddDbContext<HRProjectAPIDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Tarik")));


            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<HRProjectAPIDBContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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