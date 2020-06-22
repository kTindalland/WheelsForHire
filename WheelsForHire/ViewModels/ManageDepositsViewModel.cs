using Database;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WheelsForHire.Interfaces;
using WheelsForHire.Models;
using System.Linq;
using Prism.Commands;

namespace WheelsForHire.ViewModels
{
    public class ManageDepositsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly WheelsContext _context;
        private readonly IDamageDepositModelFactory _modelFactory;

        #region Properties

        private ObservableCollection<DamageDepositModel> _records;

        public ObservableCollection<DamageDepositModel> Records
        {
            get { return _records; }
            set { _records = value; RaisePropertyChanged(); }
        }

        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; RaisePropertyChanged(); }
        }


        #endregion

        public ICommand BackCommand { get; set; }
        public ICommand SearchUserCommand { get; set; }
        public ICommand ShowUnpaidCommand { get; set; }
        public ICommand ShowNotRefundedCommand { get; set; }
        

        public ManageDepositsViewModel(
            IRegionManager regionManager,
            WheelsContext context,
            IDamageDepositModelFactory modelFactory)
        {
            _regionManager = regionManager;
            _context = context;
            _modelFactory = modelFactory;

            BackCommand = new DelegateCommand(Back);
            SearchUserCommand = new DelegateCommand(SearchUser);
            ShowUnpaidCommand = new DelegateCommand(ShowUnpaid);
            ShowNotRefundedCommand = new DelegateCommand(ShowNotRefunded);
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void SearchUser()
        {
            // Validate id
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid) return;

            // Get all the records related to that user.
            // Damage deposits are related to a booking, and that booking is related to the customer.
            var damageDepositIds = _context.Bookings_tbl.Where(r => r.CustomerId == id).Select(r => r.DamageDepositId).ToList();

            Records = new ObservableCollection<DamageDepositModel>();

            foreach (var ddid in damageDepositIds)
            {
                Records.Add(_modelFactory.GenerateModel(ddid));
            }


        }

        private void ShowUnpaid()
        {
            var damageDepositIds = _context.DamageDeposits_tbl.Where(r => !r.Paid).Select(r => r.Id).ToList();
            
            Records = new ObservableCollection<DamageDepositModel>();

            foreach (var ddid in damageDepositIds)
            {
                Records.Add(_modelFactory.GenerateModel(ddid));
            }


        }

        private void ShowNotRefunded()
        {
            var damageDepositIds = _context.DamageDeposits_tbl.Where(r => !r.Refunded).Select(r => r.Id).ToList();
            

            Records = new ObservableCollection<DamageDepositModel>();

            foreach (var ddid in damageDepositIds)
            {
                Records.Add(_modelFactory.GenerateModel(ddid));
            }

        }
    }
}
