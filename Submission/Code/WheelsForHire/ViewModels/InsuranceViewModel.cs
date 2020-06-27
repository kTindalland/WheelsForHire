using Database;
using Database.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace WheelsForHire.ViewModels
{
    public class InsuranceViewModel : BindableBase
    {
        public ICommand BackCommand { get; set; }
        public ICommand NavToViewPoliciesCommand { get; set; }
        public ICommand CreateCompanyCommand { get; set; }
        public ICommand CreatePolicyCommand { get; set; }

        #region Properties

        private string _newCompanyName;

        public string NewCompanyName
        {
            get { return _newCompanyName; }
            set { _newCompanyName = value; RaisePropertyChanged(); }
        }

        private string _newCompanyNumber;

        public string NewCompanyNumber
        {
            get { return _newCompanyNumber; }
            set { _newCompanyNumber = value; RaisePropertyChanged(); }
        }

        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<InsuranceCompany> _insuranceCompanies;

        public ObservableCollection<InsuranceCompany> InsuranceCompanies
        {
            get { return _insuranceCompanies; }
            set { _insuranceCompanies = value; RaisePropertyChanged(); }
        }

        private int _selectedId;

        public int SelectedId
        {
            get { return _selectedId; }
            set { _selectedId = value; RaisePropertyChanged(); }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; RaisePropertyChanged(); }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; RaisePropertyChanged(); }
        }

        private string _referenceNumber;
        private readonly IRegionManager _regionManager;
        private readonly WheelsContext _context;

        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { _referenceNumber = value; RaisePropertyChanged(); }
        }


        #endregion


        public InsuranceViewModel(
            IRegionManager regionManager,
            WheelsContext context)
        {
            _regionManager = regionManager;
            _context = context;

            BackCommand = new DelegateCommand(Back);
            NavToViewPoliciesCommand = new DelegateCommand(NavToViewPolicies);
            CreateCompanyCommand = new DelegateCommand(CreateCompany);
            CreatePolicyCommand = new DelegateCommand(CreatePolicy);

            SelectedId = -1;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            InsuranceCompanies = new ObservableCollection<InsuranceCompany>(_context.InsuranceCompanies_tbl.ToList());
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void NavToViewPolicies()
        {
            _regionManager.RequestNavigate("MainRegion", "UserPolicy");
        }

        private void CreateCompany()
        {
            var newCompany = new InsuranceCompany()
            {
                Name = NewCompanyName,
                ContactNumber = NewCompanyNumber
            };

            _context.InsuranceCompanies_tbl.Add(newCompany);

            _context.SaveChanges();

            InsuranceCompanies = new ObservableCollection<InsuranceCompany>(_context.InsuranceCompanies_tbl.ToList());
            NewCompanyName = "";
            NewCompanyNumber = "";
        }

        private void CreatePolicy()
        {
            // Validate user id
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid) return;

            // Check user exists
            var userExists = _context.Customers_tbl.Any(r => r.Id == id);

            if (!userExists) return;

            // Validate a company is selected
            if (SelectedId == -1) return;

            // Validate end date is after start date
            if (EndDate.Ticks < StartDate.Ticks) return;

            // Validate there's a reference number
            if (ReferenceNumber == "") return;

            var newPolicy = new Insurance()
            {
                CustomerId = id,
                InsuranceCompanyId = SelectedId,
                StartDate = StartDate,
                EndDate = EndDate,
                Reference = ReferenceNumber
            };

            _context.Insurance_tbl.Add(newPolicy);

            _context.SaveChanges();

            ReferenceNumber = "";
            CustomerId = "";

        }

    }
}
