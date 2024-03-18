using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HR_Project.Persistence.Context;
using HR_Project.Persistence.Repositories;
using HR_Project.Application;
using HR_Project.Domain.Entitites.Common;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using HR_Project.Application.AutoMapper;
using HR_Project.Application.Services;
using HR_Project.Persistence.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(HrMapper));
builder.Services.AddDbContext<HRProjectAPIDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Tarik")));
// builder.Services.AddPersistenceServices(); 


builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<HRProjectAPIDBContext>();

// builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/api/account/login");

// builder.Services.Configure<IdentityOptions>(opt =>
// {
//     opt.User.RequireUniqueEmail = true;
// });

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<ISiteManagerRepository, SiteManagerRepository>();
builder.Services.AddTransient<ISiteManagerService, SiteManagerService>();
// builder.Services.AddTransient<PasswordHasher<AppUser>>();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7244")
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
