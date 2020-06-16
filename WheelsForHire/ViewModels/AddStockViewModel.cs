using Database;
using Database.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Regions;
using Prism.Commands;

namespace WheelsForHire.ViewModels
{
    public class AddStockViewModel : BindableBase
    {
        private readonly WheelsContext _context;
        private readonly IRegionManager _regionManager;
        private ObservableCollection<Equipment> _allEquipment;
        public ObservableCollection<Equipment> AllEquipment
        {
            get
            {
                return _allEquipment;
            }

            set
            {
                _allEquipment = value;
                RaisePropertyChanged();
            }
        }

        private int _selectedEquiptmentId;
        public int SelectedEquipmentId
        {
            get
            {
                return _selectedEquiptmentId;
            }
            set
            {
                _selectedEquiptmentId = value;
                RaisePropertyChanged();
            }
        }

        private string _stockToAdd;

        public string StockToAdd
        {
            get { return _stockToAdd; }
            set 
            {
                _stockToAdd = value;
                RaisePropertyChanged();
            }
        }

        private string _newEquipmentName;

        public string NewEquipmentName
        {
            get { return _newEquipmentName; }
            set 
            {
                _newEquipmentName = value;
                RaisePropertyChanged();
            }
        }

        private string _newEquipmentPrice;

        public string NewEquipmentPrice
        {
            get { return _newEquipmentPrice; }
            set 
            {
                _newEquipmentPrice = value;
                RaisePropertyChanged();
            }
        }




        public ICommand BackCommand { get; set; }
        public ICommand AddStockCommand { get; set; }
        public ICommand NewEquipmentCommand { get; set; }

        public AddStockViewModel(WheelsContext context,
            IRegionManager regionManager)
        {
            _context = context;
            _regionManager = regionManager;
            AllEquipment = new ObservableCollection<Equipment>(_context.Equipment_tbl.Where(r => r.Id > -1).ToList());
            SelectedEquipmentId = -1;

            BackCommand = new DelegateCommand(Back);
            AddStockCommand = new DelegateCommand(AddStock);
            NewEquipmentCommand = new DelegateCommand(NewEquipment);
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void AddStock()
        {
            // do checks
            int newStock;
            var newStockValid = int.TryParse(StockToAdd, out newStock);

            if (!newStockValid) return;

            if (SelectedEquipmentId == -1) return;


            // get equipment
            _context.Equipment_tbl.First(r => r.Id == SelectedEquipmentId).Stock += newStock;

            StockToAdd = "";

            _context.SaveChanges();
        }

        private void NewEquipment()
        {
            // do checks
            decimal price;
            var priceValid = decimal.TryParse(NewEquipmentPrice, out price);

            _context.Equipment_tbl.Add(new Equipment()
            {
                Name = NewEquipmentName,
                Price = price,
                Stock = 0
            });

            NewEquipmentName = "";
            NewEquipmentPrice = "";

            _context.SaveChanges();

            AllEquipment = new ObservableCollection<Equipment>(_context.Equipment_tbl.Where(r => r.Id > -1).ToList());
        }
    }
}
