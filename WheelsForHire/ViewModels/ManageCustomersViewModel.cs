using Database;
using Database.Models;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WheelsForHire.ViewModels
{
    public class ManageCustomersViewModel : BindableBase
    {
        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; RaisePropertyChanged(); UpdateDetails(); }
        }

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; RaisePropertyChanged(); }
        }

        private string _customerAddress;

        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; RaisePropertyChanged(); }
        }

        private string _customerPostcode;

        public string CustomerPostcode
        {
            get { return _customerPostcode; }
            set { _customerPostcode = value; RaisePropertyChanged(); }
        }

        private string _customerNumber;

        public string CustomerNumber
        {
            get { return _customerNumber; }
            set { _customerNumber = value; RaisePropertyChanged(); }
        }

        private string _inputFirstName;

        public string InputFirstName
        {
            get { return _inputFirstName; }
            set { _inputFirstName = value; RaisePropertyChanged(); }
        }

        private string _inputSurname;

        public string InputSurname
        {
            get { return _inputSurname; }
            set { _inputSurname = value; RaisePropertyChanged(); }
        }

        private string _inputAddress1;

        public string InputAddress1
        {
            get { return _inputAddress1; }
            set { _inputAddress1 = value; RaisePropertyChanged(); }
        }

        private string _inputAddress2;

        public string InputAddress2 
        {
            get { return _inputAddress2; }
            set { _inputAddress2 = value; RaisePropertyChanged(); }
        }

        private string _inputPostcode;

        public string InputPostcode
        {
            get { return _inputPostcode; }
            set { _inputPostcode = value; RaisePropertyChanged(); }
        }

        private string _inputContactNumber;
        private readonly IRegionManager _regionManager;
        private readonly WheelsContext _context;

        public string InputContactNumber
        {
            get { return _inputContactNumber; }
            set { _inputContactNumber = value; RaisePropertyChanged(); }
        }

        public ICommand CreateCustomerCommand { get; set; }
        public ICommand BackCommand { get; set; }


        public ManageCustomersViewModel(
            IRegionManager regionManager,
            WheelsContext context)
        {
            _regionManager = regionManager;
            _context = context;

            BackCommand = new DelegateCommand(Back);
            CreateCustomerCommand = new DelegateCommand(CreateCustomer);
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void CreateCustomer()
        {
            var newCustomer = new Customer()
            {
                FirstName = InputFirstName,
                Surname = InputSurname,
                AddressLine1 = InputAddress1,
                AddressLine2 = InputAddress2,
                ContactNumber = InputContactNumber,
                Postcode = InputPostcode
            };

            _context.Customers_tbl.Add(newCustomer);

            _context.SaveChanges();

        }

        private void UpdateDetails()
        {
            // Validate the customer id
            int id;
            var validId = int.TryParse(CustomerId, out id);

            if (!validId)
            {
            CustomerName = $"";
            CustomerAddress = $"";
            CustomerPostcode = $"";
            CustomerNumber = $"";
            }

            // Check that its a real customer
            var customerExists = _context.Customers_tbl.Any(r => r.Id == id);

            if (!customerExists)
            {
            CustomerName = $"";
            CustomerAddress = $"";
            CustomerPostcode = $"";
            CustomerNumber = $"";
            }

            // Get record
            var record = _context.Customers_tbl.First(r => r.Id == id);

            CustomerName = $"{record.FirstName} {record.Surname}";
            CustomerAddress = $"{record.AddressLine1} {record.AddressLine2}";
            CustomerPostcode = $"{record.Postcode}";
            CustomerNumber = $"{record.ContactNumber}";




        }


    }
}
