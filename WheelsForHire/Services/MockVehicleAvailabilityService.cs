using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Interfaces;

namespace WheelsForHire.Services
{
    public class MockVehicleAvailabilityService : IVehicleAvailabilityService
    {
        public bool FindAvailableVehicle(DateTime start, DateTime finish, int vehicleType, out int vehicleId)
        {
            vehicleId = 1;
            return true;
        }
    }

}
