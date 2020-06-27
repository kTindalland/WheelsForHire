using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Interfaces;
using System.Linq;
using Database;
using Database.Models;

namespace WheelsForHire.Services
{
    public class VehicleAvailabilityService : IVehicleAvailabilityService
    {
        private readonly WheelsContext _context;

        public VehicleAvailabilityService(WheelsContext context)
        {
            _context = context;
        }

        public bool FindAvailableVehicle(DateTime start, DateTime finish, int vehicleType, out int vehicleId)
        {
            // Get all vehicles with the right vehicle type
            var potentialVehicles = _context.Vehicles_tbl.Where(r => r.VehicleTypeId == vehicleType).ToList();

            // Check there are some
            if (potentialVehicles.Count < 1)
            {
                vehicleId = -1;
                return false;
            }

            foreach(var vehicle in potentialVehicles)
            {
                // Get current bookings for this vehicle
                var bookings = _context.Bookings_tbl.Where(r => r.VehicleId == vehicle.Id).ToList();

                var vehicleAvailable = VehicleAvailable(start, finish, vehicle, bookings);

                if (vehicleAvailable)
                {
                    // Vehicle available, book it!
                    vehicleId = vehicle.Id;
                    return true;
                }
            }

            // Got through loop without available vehicle, don't book :(
            vehicleId = -1;
            return false;
        }

        /// <summary>
        /// Checks availability for one vehicle
        /// </summary>
        /// <param name="start">The start of the potential booking</param>
        /// <param name="finish">The end of the potential booking</param>
        /// <param name="vehicle">The vehicle being checked for availability</param>
        /// <param name="currentBookings">The current bookings for this singular vehicle</param>
        /// <returns>Boolean for if the vehicle is available or not</returns>
        private bool VehicleAvailable(DateTime start, DateTime finish, Vehicle vehicle, List<Booking> currentBookings)
        {
            foreach(var booking in currentBookings)
            {
                if (booking.EndDate.Ticks < start.Ticks || booking.StartDate.Ticks > finish.Ticks)
                {
                    // Doesn't interfere, continue.
                    continue;
                }
                else
                {
                    // Does interfere, return false
                    return false;
                }
            }

            // Got through loop without intereferance, return true
            return true;
        }
    }
}
