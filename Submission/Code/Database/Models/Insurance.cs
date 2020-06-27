using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Insurance : Entity
    {
        public int CustomerId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reference { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, InsuranceCompanyId:{InsuranceCompanyId}, StartDate:{StartDate}, EndDate:{EndDate}, Reference:{Reference}";
        }
    }
}
