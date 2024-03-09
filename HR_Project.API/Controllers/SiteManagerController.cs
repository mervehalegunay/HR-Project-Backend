using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteManagerController : ControllerBase
    {
        private readonly SiteManagerService serviceManager;

        public SiteManagerController(SiteManagerService serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet("[action]")]
        // [Authorize(Roles = "SiteOwner")]
        public async Task<IActionResult> GetDetailSiteOwner(int id)
        {
            var resultSum = await serviceManager.GetDetailSiteOwner(id);

            if (id > 0)
            {
                return Ok(resultSum);
            }
            else
            {
                return NotFound("Kişi bulunamadı");
            }
        }
    }
}