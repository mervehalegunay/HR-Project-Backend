using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.Domain.Enums;

namespace HR_Project.Application.DTOs.SiteManagerDTO
{
    public class SiteManagerDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get { return (SecondName != null ? (FirstName + " " + SecondName) : FirstName) + " " + (SecondLastName != null ? (LastName + " " + SecondLastName) : (LastName)); } }
        public string? SecondName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? TCNO { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
        public Status Status { get; set; }
    }
}