using HR_Project.Application;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Persistence.Managers
{
    public class SiteManagerManager : ISiteManagerService
    {
        private readonly ISiteManagerRepository _siteManagerRepository;

        public SiteManagerManager(ISiteManagerRepository siteManagerRepository)
        {
            _siteManagerRepository = siteManagerRepository;
        }

        public async Task<bool> AddSiteManagerAsync(SiteManager siteManager)
        {
            return await _siteManagerRepository.AddAsync(siteManager);
        }

        public bool UpdateSiteManager(SiteManager siteManager)
        {
            return _siteManagerRepository.Update(siteManager);
        }

        public async Task<bool> DeleteSiteManagerAsync(int id)
        {
            var siteManager = await _siteManagerRepository.GetByIdAsync(id);
            if (siteManager == null)
                return false;

            return _siteManagerRepository.Remove(siteManager);
        }

        public async Task<SiteManager> GetSiteManagerByIdAsync(int id)
        {
            return await _siteManagerRepository.GetByIdAsync(id);
        }

        public IEnumerable<SiteManager> GetAllSiteManagers()
        {
            return _siteManagerRepository.GetAll().ToList();
        }
    }
}
