﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entitites.Common
{
    public class Person 
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? TCNO { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string? Job { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }

    }
}
