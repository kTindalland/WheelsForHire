using System;
using System.Collections.Generic;
using System.Text;

namespace WheelsForHire.Models
{
    public class InsuranceModel
    {
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reference { get; set; }
    }
}
