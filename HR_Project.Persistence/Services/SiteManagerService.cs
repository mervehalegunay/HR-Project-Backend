using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR_Project.Application;
using HR_Project.Application.DTOs.SiteManagerDTO;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites;
using HR_Project.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

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
                SiteManagerDetails resultSum = await repo.GetFilteredFirstOrDefault(select: x => new SiteManagerDetails
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SecondLastName = x.SecondLastName,
                    SecondName = x.SecondName,
                    Email = x.AppUser.Email,
                    PhoneNumber = x.PhoneNumber,
                    BirthDate = x.BirthDate,
                    BirthPlace = x.BirthPlace,
                    HireDate = x.HireDate,
                    ImagePath = x.ImagePath,
                    LeavingDate = x.LeavingDate,
                    TCNO = x.TCNO,
                }, where: x => x.Id == id && x.Status != Domain.Enums.Status.Passive, include: q => q.Include(x => x.AppUser));

                return resultSum;
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
                SiteManagerUpdate resultSum = await
                    repo.GetFilteredFirstOrDefault(select: x => new SiteManagerUpdate
                    {
                        AddressDetail = x.AddressDetail,
                        City = x.City,
                        District = x.District,
                        ImagePath = x.ImagePath,
                        PhoneNumber = x.PhoneNumber

                    }, where: x => x.Id == id && x.Status != Domain.Enums.Status.Passive);

                return resultSum;
            }
            else
            {
                return null;
            }
        }
    }
}