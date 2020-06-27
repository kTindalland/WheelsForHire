using System;
using System.Collections.Generic;
using System.Text;

namespace WheelsForHire.Interfaces
{
    public interface IVehicleAvailabilityService
    {
        bool FindAvailableVehicle(DateTime start, DateTime finish, int vehicleType, out int vehicleId);
    }
}
