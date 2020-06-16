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
                RaisePropertyChanged();
                _allEquipment = value;
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
                RaisePropertyChanged();
                _selectedEquiptmentId = value;
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

        }

        private void NewEquipment()
        {

        }
    }
}
