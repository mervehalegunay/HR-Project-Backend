using HR_Project.Application;
using HR_Project.Domain.Entitites;
using HR_Project.Domain.Entitites.Common;
using HR_Project.Persistence.Context;

namespace HR_Project.Persistence.Repositories;

public class SiteManagerRepository : BaseRepository<SiteManager> , ISiteManagerRepository 
{
    public SiteManagerRepository(HRProjectAPIDBContext db) : base(db)
    {
        
    }
}
