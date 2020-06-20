using Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WheelsForHire.Models;

namespace WheelsForHire.ViewModels
{
    public class UsersPolicyViewModel : BindableBase
    {
        public ICommand BackCommand { get; set; }
        public ICommand FindPoliciesCommand { get; set; }

        private string _customerId;
        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<InsuranceModel> _records;
        private readonly IRegionManager _regionManager;
        private readonly WheelsContext _context;

        public ObservableCollection<InsuranceModel> Records
        {
            get { return _records; }
            set { _records = value; RaisePropertyChanged(); }
        }



        public UsersPolicyViewModel(IRegionManager regionManager,
            WheelsContext context)
        {
            _regionManager = regionManager;
            _context = context;
            BackCommand = new DelegateCommand(Back);
            FindPoliciesCommand = new DelegateCommand(FindPolicies);

            Records = new ObservableCollection<InsuranceModel>();
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "Insurance");
        }

        private void FindPolicies()
        {
            Records = new ObservableCollection<InsuranceModel>();

            // Validate CustomerId
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid) return;

            // get the records
            var records = _context.Insurance_tbl.Where(r => r.CustomerId == id).ToList();

            // Get all the insurance companies, saves requesting db each time.
            var companies = _context.InsuranceCompanies_tbl.ToList();

            // Structure results

            foreach (var record in records)
            {
                var newModel = new InsuranceModel()
                {
                    StartDate = record.StartDate,
                    EndDate = record.EndDate,
                    Reference = record.Reference,
                    Company = companies.First(r => r.Id == record.InsuranceCompanyId).Name
                };

                Records.Add(newModel);
            }
        }

    }
}
