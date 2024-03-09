using AutoMapper;
using HR_Project.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services
{
    public class SiteManagerService
    {
        private readonly ISiteManagerRepository siteOwnerRepository;
        private readonly IMapper mapper;

        public SiteManagerService(ISiteManagerRepository siteOwnerRepository, IMapper mapper)
        {
            this.siteOwnerRepository = siteOwnerRepository;
            this.mapper = mapper;
        }

        public async Task<Person> GetDetailSiteOwner(int id)
        {
            if (id > 0)
            {
                Person resultSum = await siteOwnerRepository.GetFilteredFirstOrDefault(select: x => new Person
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SecondLastName = x.SecondLastName,
                    SecondName = x.SecondName,
                    Address = x.Address,
                    Email = x.AppUser.Email,
                    PhoneNumber = x.PhoneNumber,
                    BirthDate = x.BirthDate,
                    BirthPlace = x.BirthPlace,
                    HireDate = x.HireDate,
                    ImagePath = x.ImagePath,
                    LeavingDate = x.LeavingDate,
                    TCNO = x.TCNO,
                }, where: x => x.Id == id && x.Status != Domain.Enums.Status.Passive, include: q => q.Include(x => x.AppUser).Include(x => x.Job));

                return resultSum;
            }
            else
            {
                return null;
            }
        }

        public async Task<Person> GetSumSiteOwner(int id)
        {
            if (id > 0)
            {
                Person resultSum = await
                    siteOwnerRepository.GetFilteredFirstOrDefault(select: x => new Person
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        SecondLastName = x.SecondLastName,
                        SecondName = x.SecondName,
                        Address = x.Address,
                        Email = x.AppUser.Email,
                        PhoneNumber = x.PhoneNumber,
                    }, where: x => x.Id == id && x.Status != Domain.Enums.Status.Passive, include: q => q.Include(x => x.AppUser).Include(x => x.Job));
                return resultSum;

            }
            else
            {
                return null;
            }
        }

        public async Task<Person> GetUpdateSiteOwner(int id)
        {
            if (id > 0)
            {
                Person resultSum = await siteOwnerRepository.GetFilteredFirstOrDefault(select: x => new Person
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
