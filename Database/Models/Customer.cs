using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string ContactNumber { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, FirstName:{FirstName}, Surname:{Surname}, AddressLine1:{AddressLine1}, AddressLine2:{AddressLine2}, Postcode:{Postcode}, ContactNumber:{ContactNumber}";
        }

    }
}
