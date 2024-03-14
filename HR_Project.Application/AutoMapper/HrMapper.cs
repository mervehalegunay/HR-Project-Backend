using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR_Project.Application.DTOs.SiteManagerDTO;
using HR_Project.Domain.Entitites;

namespace HR_Project.Application.AutoMapper
{
    public class HrMapper : Profile
    {
        public HrMapper() 
        {
            CreateMap<SiteManagerDetails, SiteManager>().ReverseMap();

        }
    }
}