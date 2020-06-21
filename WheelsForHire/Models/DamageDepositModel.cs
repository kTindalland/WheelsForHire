using Database;
using Database.Models;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WheelsForHire.Models
{
    public class DamageDepositModel
    {
        private readonly WheelsContext _context;
        private readonly IRegionManager _regionManager;

        public string DamageDepositId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Amount { get; set; }
        public string Paid { get; set; }
        public string Refunded { get; set; }

        public ICommand PayDepositCommand { get; set; }
        public ICommand RefundCommand { get; set; }

        public DamageDepositModel(
            WheelsContext context,
            IRegionManager regionManager)
        {
            _context = context;
            _regionManager = regionManager;

            PayDepositCommand = new DelegateCommand(PayDeposit);
            RefundCommand = new DelegateCommand(Refund);
        }

        private void PayDeposit()
        {
            int id;
            var valid = int.TryParse(DamageDepositId, out id);

            if (!valid) return;

            _context.DamageDeposits_tbl.First(r => r.Id == id).Paid = true;
            _context.SaveChanges();
        }

        private void Refund()
        {
            int id;
            var valid = int.TryParse(DamageDepositId, out id);

            if (!valid) return;

            _context.DamageDeposits_tbl.First(r => r.Id == id).Refunded = true;
            _context.SaveChanges();
        }
    }
}
