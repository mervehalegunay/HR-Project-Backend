using HR_Project.Application.DTOs.SiteManagerDTO;
using HR_Project.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Application.Services
{
    public interface ISiteManagerService
    {
        Task<SiteManagerDetails> GetSiteManagerDetails(int id);
        Task<SiteManagerUpdate> UpdateSiteManager(int id);
    }
}
