using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HR_Project.Application.DTOs.SiteManagerDTO
{
    public class SiteManagerUpdate
    {
        
        public string? ImagePath { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? AddressDetail { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile? UploadPath { get; set; }
    }
}