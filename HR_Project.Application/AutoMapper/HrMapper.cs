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
            CreateMap<SiteManager , SiteManagerDetails>().ForMember(d=>d.FullName, o=>o.MapFrom(src=>src.FirstName + " " + src.LastName));
            
            CreateMap<SiteManager , SiteManagerUpdate>();
            
        }
    }
}