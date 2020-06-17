using System;
using System.Collections.Generic;
using System.Text;

namespace WheelsForHire.Interfaces
{
    public interface IVehiclePriceCalculatorService
    {
        decimal CalculatePrice(DateTime start, DateTime finish, int vehicleId);
    }
}
