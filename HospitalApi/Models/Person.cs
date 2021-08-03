using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalApi.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}