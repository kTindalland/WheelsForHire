using Database;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Database.Models;
using Prism.Commands;
using Prism.Regions;

namespace WheelsForHire.ViewModels
{
    public class AdHocViewModel : BindableBase
    {
        private readonly WheelsContext _context;
        private readonly IRegionManager _regionManager;
        private string _queryString;
        public string QueryString
        {
            get { return _queryString; }
            set 
            {
                _queryString = value;
                RaisePropertyChanged();
            }
        }

        private string _commandString;
        public string CommandString
        {
            get { return _commandString; }
            set 
            {
                _commandString = value;
                RaisePropertyChanged();
            }
        }

        // Combobox props
        private ObservableCollection<string> _tableNames;
        public ObservableCollection<string> TableNames
        {
            get { return _tableNames; }
            set 
            { 
                _tableNames = value;
                RaisePropertyChanged();
            }
        }

        // Results view
        private ObservableCollection<Entity> _results;
        public ObservableCollection<Entity> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged();
            }
        }

        private string _selectedTable;
        public string SelectedTable
        {
            get { return _selectedTable; }
            set
            { 
                _selectedTable = value;
                RaisePropertyChanged();
            }
        }



        public ICommand ExecuteQueryCommand { get; set; }
        public ICommand ExecuteCommandCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public AdHocViewModel(
            WheelsContext context,
            IRegionManager regionManager)
        {
            _context = context;
            _regionManager = regionManager;
            var tableNames = new List<string>()
            {
                "Bookings_tbl",
                "Customers_tbl",
                "DamageDeposits_tbl",
                "Equipment_tbl",
                "Insurance_tbl",
                "InsuranceCompanies_tbl",
                "Sales_tbl",
                "Vehicles_tbl",
                "VehicleTypes_tbl"
            };

            TableNames = new ObservableCollection<string>(tableNames);

            ExecuteQueryCommand = new DelegateCommand(ExecuteQuery);
            BackCommand = new DelegateCommand(Back);
        }

        private void Back()
        {
            _regionManager.RequestNavigate("MainRegion", "FunctionSelect");
        }

        private void ExecuteQuery()
        {
            List<Entity> result;

            switch (SelectedTable)
            {
                case "Bookings_tbl":
                    result = _context.Bookings_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "Customers_tbl":
                    result = _context.Customers_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "DamageDeposits_tbl":
                    result = _context.DamageDeposits_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "Equipment_tbl":
                    result = _context.Equipment_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "Insurance_tbl":
                    result = _context.Insurance_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "InsuranceCompanies_tbl":
                    result = _context.InsuranceCompanies_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "Sales_tbl":
                    result = _context.Sales_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "Vehicles_tbl":
                    result = _context.Vehicles_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                case "VehicleTypes_tbl":
                    result = _context.VehicleTypes_tbl.FromSqlRaw(QueryString).ToList<Entity>();
                    break;

                default:
                    result = new List<Entity>();
                    break;
            }

            Results = new ObservableCollection<Entity>(result);
        }

        private void ExecuteCommand()
        {

        }

    }
}
