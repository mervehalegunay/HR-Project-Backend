using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Project.Domain.Entitites.Common
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string? FullName { get { return FirstName + " " + LastName; } }

        public string? SecondName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TCNO { get; set; }
        public string BirthPlace { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get { return AddressDetail + " " + District.ToUpper() + "/" + City.ToUpper(); } }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetail { get; set; }
        public decimal Salary { get; set; }
        public string? ImagePath { get; set; }
    }
}
