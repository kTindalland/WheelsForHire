using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reference { get; set; }
    }
}
