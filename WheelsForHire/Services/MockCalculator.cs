using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Interfaces;

namespace WheelsForHire.Services
{
    public class MockCalculator : IVehiclePriceCalculatorService
    {
        public decimal CalculatePrice(DateTime start, DateTime finish, int vehicleId)
        {
            return 10.0m;
        }
    }
}
