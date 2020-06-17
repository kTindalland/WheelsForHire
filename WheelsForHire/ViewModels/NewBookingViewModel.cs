using Database;
using Database.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using WheelsForHire.Interfaces;

namespace WheelsForHire.ViewModels
{
    public class NewBookingViewModel : BindableBase
    {
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set 
            { 
                _customerName = value;
                RaisePropertyChanged();
            }
        }
        
        private string _customerAddress;
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set 
            { 
                _customerAddress = value;
                RaisePropertyChanged();
            }
        }

        private string _customerNumber;
        public string CustomerNumber
        {
            get { return _customerNumber; }
            set 
            { 
                _customerNumber = value;
                RaisePropertyChanged();
            }
        }

        private string _customerId;
        public string CustomerId
        {
            get { return _customerId; }
            set 
            { 
                _customerId = value;
                RaisePropertyChanged();
                SetCustomerDetails();
            }
        }

        private ObservableCollection<VehicleType> _vehicleTypes;
        public ObservableCollection<VehicleType> VehicleTypes
        {
            get { return _vehicleTypes; }
            set 
            { 
                _vehicleTypes = value;
                RaisePropertyChanged();
            }
        }

        private int _selectedType;
        public int SelectedType
        {
            get { return _selectedType; }
            set 
            { 
                _selectedType = value;
                RaisePropertyChanged();
            }
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set 
            { 
                _fromDate = value;
                RaisePropertyChanged();
            }
        }

        private DateTime _toDate;
        private readonly WheelsContext _context;
        private readonly IRegionManager _regionManager;
        private readonly IVehicleAvailabilityService _vehicleAvailability;
        private readonly IVehiclePriceCalculatorService _priceCalculator;

        public DateTime ToDate
        {
            get { return _toDate; }
            set 
            {
                _toDate = value;
                RaisePropertyChanged();
            }
        }

        public ICommand BackCommand { get; set; }
        public ICommand BookCommand { get; set; }


        public NewBookingViewModel(
            WheelsContext context,
            IRegionManager regionManager,
            IVehicleAvailabilityService vehicleAvailability,
            IVehiclePriceCalculatorService priceCalculator)
        {
            VehicleTypes = new ObservableCollection<VehicleType>(context.VehicleTypes_tbl.ToList());
            _context = context;
            _regionManager = regionManager;
            _vehicleAvailability = vehicleAvailability;
            _priceCalculator = priceCalculator;
            SelectedType = -1;

            BackCommand = new DelegateCommand(Back);
            BookCommand = new DelegateCommand(Book);

            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void Book()
        {
            // Validate id 
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid) return;

            // Validate type id
            if (SelectedType <= 0) return;

            // Check dates in order
            if (ToDate.Ticks < FromDate.Ticks) return;

            // Check availability
            int vehicleId;
            var vehicleAvailable = _vehicleAvailability.FindAvailableVehicle(FromDate, ToDate, SelectedType, out vehicleId);
            if (!vehicleAvailable) return;

            // checks done, send it
            var newDamageDeposit = new DamageDeposit()
            {
                Paid = false,
                Refunded = false,
                Price = 140
            };

            _context.DamageDeposits_tbl.Add(newDamageDeposit);
            _context.SaveChanges();

            // Get price
            var price = _priceCalculator.CalculatePrice(FromDate, ToDate, vehicleId);

            var newBooking = new Booking()
            {
                CustomerId = id,
                AmountPaid = 0,
                StartDate = FromDate,
                EndDate = ToDate,
                DamageDepositId = newDamageDeposit.Id,
                VehicleId = vehicleId,
                Price = price
            };

            _context.Bookings_tbl.Add(newBooking);
            _context.SaveChanges();

            CustomerId = "";
            

        }

        private void SetCustomerDetails()
        {
            // Validate id 
            int id;
            var valid = int.TryParse(CustomerId, out id);

            if (!valid)
            {
                CustomerName = "";
                CustomerAddress = "";
                CustomerNumber = "";
                return;
            }

            // Check customer exists
            var customerExists = _context.Customers_tbl.Any(r => r.Id == id);

            if (!customerExists)
            {
                CustomerName = "";
                CustomerAddress = "";
                CustomerNumber = "";
                return;
            }

            // Valid ID and customer exists, populate fields.
            var customer = _context.Customers_tbl.First(r => r.Id == id);

            CustomerName = $"{customer.FirstName} {customer.Surname}";
            CustomerAddress = $"{customer.AddressLine1} {customer.AddressLine2}, {customer.Postcode}";
            CustomerNumber = $"{customer.ContactNumber}";
        }

    }
}
