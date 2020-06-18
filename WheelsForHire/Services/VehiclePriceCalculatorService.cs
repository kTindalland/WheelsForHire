using Database;
using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Interfaces;
using System.Linq;

namespace WheelsForHire.Services
{
    public class VehiclePriceCalculatorService : IVehiclePriceCalculatorService
    {
        private readonly WheelsContext _context;

        public VehiclePriceCalculatorService(WheelsContext context)
        {
            _context = context;
        }

        public decimal CalculatePrice(DateTime start, DateTime finish, int vehicleId)
        {
            // Get time between two dates
            var difference = finish - start;

            // Get days not belonging to a week
            var days = difference.Days % 7;

            // Get weeks
            var weeks = (difference.Days - days) / 7;

            // Instanciate price var
            decimal totalPrice = 0m;

            // Get vehicle
            var vehicle = _context.Vehicles_tbl.First(r => r.Id == vehicleId);

            // Get the type for prices
            var vehicleType = _context.VehicleTypes_tbl.First(r => r.Id == vehicle.VehicleTypeId);

            // Tot up prices
            totalPrice += days * vehicleType.DailyCharge;
            totalPrice += weeks * vehicleType.WeeklyCharge;

            // Check for zero price, for same day returns, charge a day
            if (totalPrice == 0m) totalPrice = vehicleType.DailyCharge;

            // All done :)
            return totalPrice;
        }
    }
}
