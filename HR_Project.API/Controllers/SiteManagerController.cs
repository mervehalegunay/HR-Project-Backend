using System;
using System.Collections.Generic;
using System.Data.Common;
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
        private readonly ISiteManagerService _siteManagerService;

        public SiteManagerController(ISiteManagerService siteManager)
        {
            _siteManagerService = siteManager;
        }

      
        /////////////////////////////////////////////////////////
        /// ORNEK OLSUN DIYE ASAGI BIRAKIYORUM HATALAR CIKABILIR DUZELTIRIZ
        /// /////////////////////////////////////////////////////////////

        
       [HttpPost]
        public async Task<IActionResult> AddSiteManagerAsync(SiteManager siteManager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _siteManagerService.AddSiteManagerAsync(siteManager);
            if (result)
                return Ok(new { Message = "Site Manager added successfully" });

            return BadRequest(new { Message = "Failed to add Site Manager" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSiteManager(int id, SiteManager siteManager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            siteManager.Id = id;
            var result = _siteManagerService.UpdateSiteManager(siteManager);
            if (result)
                return Ok(new { Message = "Site Manager updated successfully" });

            return NotFound(new { Message = "Site Manager not found" });
        }


        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteSiteManager(int id)
        // {
        //     var result = await _siteManagerService.DeleteSiteManagerAsync(id);
        //     if (result)
        //         return Ok("Site Manager deleted successfully");
        //     return NotFound("Site Manager not found");
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetSiteManagerById(int id)
        // {
        //     var siteManager = await _siteManagerService.GetSiteManagerByIdAsync(id);
        //     if (siteManager != null)
        //         return Ok(siteManager);
        //     return NotFound("Site Manager not found");
        // }

        [HttpGet]
        [Route("GetSiteManager")]
        public async Task<IEnumerable<SiteManager>> GetAllSiteManagers()
        {
            return await _siteManagerService.GetAllSiteManagersAsync();
        }

       

    }
}