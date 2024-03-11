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
        Task<bool> AddSiteManagerAsync(SiteManager siteManager);
        bool UpdateSiteManager(SiteManager siteManager);
        Task<bool> DeleteSiteManagerAsync(int id);
        Task<SiteManager> GetSiteManagerByIdAsync(int id);
        Task<IEnumerable<SiteManager>> GetAllSiteManagersAsync();
    }
}
