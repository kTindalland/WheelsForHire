using Database;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using WheelsForHire.Interfaces;
using WheelsForHire.Models;
using System.Linq;
using Prism.Regions;
using System.Runtime.InteropServices.ComTypes;

namespace WheelsForHire.Factories
{
    public class DamageDepositModelFactory : IDamageDepositModelFactory
    {
        private readonly WheelsContext _context;

        public DamageDepositModelFactory(
            WheelsContext context)
        {
            _context = context;
        }

        public DamageDepositModel GenerateModel(int damageDepositId)
        {
            // Validate it's a valid id
            var valid = _context.DamageDeposits_tbl.Any(r => r.Id == damageDepositId);

            if (!valid)
            {
                var badResult = new DamageDepositModel(_context);
            }

            var record = _context.DamageDeposits_tbl.First(r => r.Id == damageDepositId);
            var customerId = _context.Bookings_tbl.First(r => r.DamageDepositId == damageDepositId).CustomerId;
            var customer = _context.Customers_tbl.First(r => r.Id == customerId);

            var model = new DamageDepositModel(_context)
            {
                Amount = record.Price.ToString(),
                CustomerId = customerId.ToString(),
                CustomerName = $"{customer.FirstName} {customer.Surname}",
                DamageDepositId = damageDepositId.ToString(),
                Paid = record.Paid ? "Yes" : "No",
                Refunded = record.Refunded ? "Yes" : "No"
            };

            return model;
        }
    }
}
