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

namespace WheelsForHire.ViewModels
{
    public class EquipmentSalesViewModel : BindableBase
    {
        private readonly WheelsContext _context;
        private readonly IRegionManager _regionManager;

        private ObservableCollection<Equipment> _equipmentList;
        public ObservableCollection<Equipment> EquipmentList
        {
            get { return _equipmentList; }
            set 
            {
                _equipmentList = value;
                RaisePropertyChanged();
            }
        }

        private int _equipment;
        public int SelectedEquipment
        {
            get { return _equipment; }
            set { _equipment = value; RaisePropertyChanged(); }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged(); }
        }

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

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; RaisePropertyChanged(); }
        }



        public ICommand BackCommand { get; set; }
        public ICommand MakeSaleCommand { get; set; }

        public EquipmentSalesViewModel(
            WheelsContext context,
            IRegionManager regionManager)
        {
            _context = context;
            _regionManager = regionManager;

            BackCommand = new DelegateCommand(Back);
            MakeSaleCommand = new DelegateCommand(MakeSale);
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void MakeSale()
        {
            // Validate user id
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid) return;

            // Check user exists
            var userExists = _context.Customers_tbl.Any(r => r.Id == id);

            if (!userExists) return;

            // Validate the quantity
            int quantity;
            var quantityValid = int.TryParse(Quantity, out quantity);

            if (!quantityValid) return;

            // Validate the equipment
            if (SelectedEquipment <= 0) return;

            // Check equipment exists
            var equipmentExists = _context.Equipment_tbl.Any(r => r.Id == id);

            if (!equipmentExists) return;

            // All valid, make the sale
            var newSale = new Sale()
            {
                CustomerId = id,
                Quantity = quantity,
                EquipmentId = SelectedEquipment,
                DateOfSale = DateTime.Now
            };

            _context.Sales_tbl.Add(newSale);
            _context.SaveChanges();
        }

        private void UpdateDetails()
        {
            // Validate user id
            int id;
            var idValid = int.TryParse(CustomerId, out id);

            if (!idValid)
            {
                CustomerName = $"";
                CustomerAddress = $"";
                return;
            }

            // Check user exists
            var userExists = _context.Customers_tbl.Any(r => r.Id == id);

            if (!userExists)
            {
                CustomerName = $"";
                CustomerAddress = $"";
                return;
            }

            // Get user
            var user = _context.Customers_tbl.First(r => r.Id == id);

            // Populate fields
            CustomerName = $"{user.FirstName} {user.Surname}";
            CustomerAddress = $"{user.AddressLine1} {user.AddressLine2}";
        }
    }
}
