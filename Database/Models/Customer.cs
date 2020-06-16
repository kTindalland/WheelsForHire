using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public int ContactNumber { get; set; }

    }
}
