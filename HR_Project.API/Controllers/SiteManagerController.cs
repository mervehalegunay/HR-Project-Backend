using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Application.DTOs.SiteManagerDTO;
using HR_Project.Application.Services;
using HR_Project.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteManagerController : ControllerBase
    {
        private readonly ISiteManagerService SmService;

        public SiteManagerController(ISiteManagerService siteManager)
        {
            SmService = siteManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetSiteManager(int id)
        {
            SiteManagerDetails manager = await SmService.GetSiteManagerDetails(id);
            if (manager != null)
            {
                return Ok(manager);
            }
            else
            {
                return NotFound("Kişi Bulunamadı");
            }

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSiteManager(int id)
        {
            SiteManagerUpdate manager = await SmService.UpdateSiteManager(id);
            return Ok(manager);
        }

    }
}