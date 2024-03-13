using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR_Project.Application;
using HR_Project.Application.DTOs.SiteManagerDTO;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites;

namespace HR_Project.Persistence.Services
{
    public class SiteManagerService : ISiteManagerService
    {
        private readonly ISiteManagerRepository repo;
        private readonly IMapper mapper;

        public SiteManagerService(ISiteManagerRepository repo , IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<SiteManagerDetails> GetSiteManagerDetails(int id)
        {
            if (id > 0)
            {
                var siteManager = repo.GetByIdAsync(id);
                var siteManagerDetails = mapper.Map<SiteManagerDetails>(siteManager);
                return siteManagerDetails;   
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Bu metodu tekrar gözden geçirmek gerekiyor!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SiteManagerUpdate> UpdateSiteManager(int id)
        {
            if (id>0)
            {
                var siteManager = repo.GetByIdAsync(id);
                var SiteManagerUpdate = mapper.Map<SiteManagerUpdate>(siteManager);
                return SiteManagerUpdate; 

            }
            else
            {
                
            return null;
            }
        }
    }
}